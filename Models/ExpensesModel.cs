using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExpMngr.Models
{
    public class ExpensesModel
    {
        public int Expense_ID { get; set; }
        public decimal Amount { get; set; }
        public int Expense_Type_ID { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public bool isDeleted { get; set; }
        public DateTime TimeStamp { get; set; } 
    }
}