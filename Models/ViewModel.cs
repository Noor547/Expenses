using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpMngr.Models
{
    public class ViewModel
    {
        public UserLogin User { get; set; }
        public ExpenseType Expense { get; set; }
        public BudgetModel Budget { get; set; }
    }
}