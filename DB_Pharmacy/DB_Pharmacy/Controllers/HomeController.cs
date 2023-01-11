using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB_Pharmacy.Filters;

namespace DB_Pharmacy.Controllers
{
    [AuthorizedUser]
    [ExceptionFilter]
    public class HomeController : Controller 
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Login","Login");
        }

        public ActionResult Myaccount()
        {
            return View();
            //throw new Exception("Something Went wrong");
        }
    }
}