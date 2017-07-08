using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpMngr.Models
{
    public class BudgetModel
    {
        public int Budget_id { get; set; }
        public decimal Amount { get; set; }
        public int Lk_Budget_Type_Id { get; set; }
        public string Description { get; set; }
        public int User_Id { get; set; }
        public bool isDeleted { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}