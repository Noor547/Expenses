using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpMngr.Models
{
    public class ExpenseType
    {
        public int Expense_Type_ID { get; set; }
        public string Expense_Type { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}