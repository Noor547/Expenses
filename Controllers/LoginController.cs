using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpMngr.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Authenticate(Models.UserLogin lg)
        {
            if (lg.UserName != null && lg.Password != null)
            {
                Repository.LoginRepository emp = new Repository.LoginRepository();
                List<Models.UserLogin> lstEmp = emp.Authenticate(lg);
                return Json(lstEmp, JsonRequestBehavior.AllowGet);
            }
            else
            {
                throw new Exception("Please supply UserName / Password");
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Register(Models.UserLogin lg)
        {
            bool isSuccess = false;
            if (lg.UserName != null && lg.Password != null && lg.ProfileName != null)
            {
                Repository.LoginRepository emp = new Repository.LoginRepository();
                isSuccess = emp.AddUsers(lg);
                return Json(isSuccess, JsonRequestBehavior.AllowGet);
            }
            return Json(isSuccess, JsonRequestBehavior.AllowGet);
        }
    }
}