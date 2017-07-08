using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpMngr.Models
{
    public class LkBudgetTypeModel
    {
        public int Lk_Budget_Type_Id { get; set; }
        public string Budget_Type { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
        public DateTime Time_stamp { get; set; }
    }
}