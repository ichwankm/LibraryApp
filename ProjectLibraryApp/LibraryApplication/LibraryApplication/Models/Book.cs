using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class Book
    {
        public int Book_ID_PK { get; set; }
        public string Book_Name { get; set; }
        public decimal Book_Price { get; set; }
        public int Book_Amount { get; set; }
    }
}
