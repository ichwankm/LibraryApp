using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class Transaction
    {
        public int Transaction_ID_PK { get; set; }
        public int Book_ID_FK { get; set; }
        public string Book_Name { get; set; }
        public decimal Book_Price { get; set; }
        public int User_ID_FK { get; set; }
        public string Username { get; set; }
        public string Borrow_Date { get; set; }
        public string Return_Date { get; set; }
        public bool IsDoneBorrow { get; set; }
    }
}
