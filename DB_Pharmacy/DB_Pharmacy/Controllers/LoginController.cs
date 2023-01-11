using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB_Pharmacy.Models;
using DB_Pharmacy.Manager;
using DB_Pharmacy.Filters;

namespace DB_Pharmacy.Controllers
{
    [ExceptionFilter]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Loginmodel logindata)
        {
            if (ModelState.IsValid)
            {
                Loginmanager obj = new Loginmanager();
                Employeemodel empdata = obj.checklogin(logindata);
                if (empdata != null)
                {
                    Session["islogin"] = true;
                    Session["EID"] = empdata.EID;
                    Session["LoginID"] = empdata.logininfo.LoginID;
                    Session["PersonName"] = empdata.FirstName + " " + empdata.LastName;
                    Session["PersonImage"] = empdata.Imagepath;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = "Username or Passwaord is Incorrect";
                    return View();
                }

            }
            else
            {
                ViewBag.message = "Please Enter Usename and Password";
                return View();
            }
            
        }
    }
}