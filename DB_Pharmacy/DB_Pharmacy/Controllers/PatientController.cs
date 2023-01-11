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
    [AuthorizedUser]
    [ExceptionFilter]
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Addpatient()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Addpatient(PatientModel PAT)
        {
            if (ModelState.IsValid)
            {

                PatientManager obj = new PatientManager();
                int check = obj.Addpatient(PAT);
                if (check > 0)
                {
                    TempData["message"] = "Your PatientID: " + check;
                    return RedirectToAction("Viewpatient");
                }
                else
                {
                    TempData["message"] = "Enter Records of Patient";
                    return View();
                }

            }
            else
            {
                TempData["message"] = "Enter Valid Informarion";
                return View();
            }
        }

        public ActionResult Viewpatient()
        {
            PatientManager obj = new PatientManager();
            List<PatientModel> PatInfo = obj.GetallPatient();
            return View(PatInfo);
        }

        [HttpGet]
        public ActionResult Editpatient(int PID)
        {
            PatientManager obj = new PatientManager();
            PatientModel PAT = obj.GetPat(PID);
            return View(PAT);
        }


        [HttpPost]
        public ActionResult Editpatient(PatientModel PAT)
        {
            PatientManager obj = new PatientManager();
            bool check = obj.EditPat(PAT);
            if (check)
            {
                return RedirectToAction("Viewpatient");
            }
            else
            {
                TempData["message"] = "Error Ocured Try again";
                return View(PAT);
            }
        }
    }
}