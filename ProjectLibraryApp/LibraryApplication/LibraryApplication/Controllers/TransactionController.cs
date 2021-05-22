using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using LibraryApplication.Models;

namespace LibraryApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TransactionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select Transaction_ID_PK, Book_ID_FK, Book_Name, Book_Price, User_ID_FK, Username, Borrow_Date, Return_Date, IsDoneBorrow from TblT_Transaction t
                    join TblM_Book b on t.Book_ID_FK = b.Book_ID_PK
                    join TblM_User u on t.User_ID_FK = u.User_ID_PK";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("LibraryAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Transaction transaction)
        {
            string query = @"
                    IF ((select Book_Amount from TblM_Book where Book_ID_PK = '" + transaction.Book_ID_FK + @"') = 0)
	                    SELECT 'Buku sudah habis terpinjam' AS Message
                    ELSE
                        insert into TblT_Transaction (Book_ID_FK, User_ID_FK, Borrow_Date, Return_Date, IsDoneBorrow) values
                        ('" + transaction.Book_ID_FK + @"', '" + transaction.User_ID_FK + @"', '" + transaction.Borrow_Date + @"', '" + transaction.Return_Date + @"', 'Not Done')
	                    update TblM_Book set Book_Amount = Book_Amount - 1 where Book_ID_PK = '" + transaction.Book_ID_FK + @"'
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("LibraryAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Addedd Successfully");
        }

        [HttpPut]
        public JsonResult Put(Transaction transaction)
        {
            string query = @"
                    update dbo.TblT_Transaction set
                    IsDoneBorrow = 'Done'
                    where Transaction_ID_PK = " + transaction.Transaction_ID_PK + @"
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("LibraryAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }
    }
}
