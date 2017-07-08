using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpMngr.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Expense(int id)
        {
            List<Models.ExpenseType> lstExpenses = new List<Models.ExpenseType>();
            Repository.ExpensesRepository expr = new Repository.ExpensesRepository();
            lstExpenses = expr.GetExpensesType();
            IEnumerable<SelectListItem> expTypeList = new SelectList(lstExpenses, "Expense_Type_ID", "Expense_Type");
            ViewBag.Expenses = expTypeList;


            Repository.LoginRepository lrp = new Repository.LoginRepository();
            Models.ViewModel ur = new Models.ViewModel();
            ur.User = lrp.GetUserDetails(id);
            return View(ur);
        }

        public ActionResult AddExpenses(Models.ExpensesModel em)
        {
            Repository.ExpensesRepository erp = new Repository.ExpensesRepository();
            if (em.Amount != 0 && em.CreatedBy != 0 && em.Expense_Type_ID != 0)
            {
                erp.AddExpenses(em);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Budget()
        {
            return View();
        }
    }
}