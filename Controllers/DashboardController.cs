using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpMngr.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index(int id)
        {
            Repository.LoginRepository lrp = new Repository.LoginRepository();
            Models.UserLogin ur = new Models.UserLogin();
			ur = lrp.GetUserDetails(id);
            return View(ur);
        }
    }
}