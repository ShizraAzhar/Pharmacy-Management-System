using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB_Pharmacy.Filters;
using DB_Pharmacy.Models;
using DB_Pharmacy.Manager;
using System.IO;

namespace DB_Pharmacy.Controllers
{

    [AuthorizedUser]
    [ExceptionFilter]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Addemp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addemp(Employeemodel Emp, HttpPostedFileBase ImageFile)                                                                                                                    
        {
            if (ModelState.IsValid)
            {
                if (ImageFile == null)
                {
                    TempData["message"] = "Please Upload Employee Image";
                    return View();
                }
                else
                {
                    string Filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    string Extension = Path.GetExtension(ImageFile.FileName);
                    Filename = Filename + DateTime.Now.ToString("yymmssfff") + Extension;
                    Emp.Imagepath = "~/ProjectData/" + Filename;
                    Filename = Path.Combine(Server.MapPath("~/ProjectData/"), Filename);
                    ImageFile.SaveAs(Filename);

                    Employeemanager obj = new Employeemanager();
                    int check = obj.Addemp(Emp);
                    if (check > 0)
                    {
                        TempData["message"] = "Your EmployeeID: " + check;
                        return RedirectToAction("Viewemp");
                    }
                    else
                    {
                        TempData["message"] = "Enter Item to be Inserted";
                        return View();
                    }

                }


            }
            else
            {
                TempData["message"] = "Enter Valid Item";
                return View();
            }
        }


        public ActionResult Viewemp()
        {
            Employeemanager obj = new Employeemanager();
            List<Employeemodel> empinfo = obj.GetAllEmp();
            return View(empinfo);
        }

        public ActionResult Deleteemp(int EID)
        {
            Employeemanager obj = new Employeemanager();
            bool check = obj.removeemp(EID);
            if (check)
            {
                TempData["Message"] = "data deleted successfulyl";
            }
            else
            {
                TempData["Message"] = "data dosen't delete, something wrong";
            }
            return RedirectToAction("Viewemp");
        }

        [HttpGet]
        public ActionResult Updateemp(int EID)
        {
            

            Employeemanager obj = new Employeemanager();
            Employeemodel emp = obj.getemp(EID);
            
            return View(emp);
        }

        [HttpPost]
        public ActionResult Updateemp(Employeemodel Emp)
        {
            Employeemanager obj = new Employeemanager();
            bool check = obj.updateemp(Emp);
            if (check)
            {
                return RedirectToAction("Viewemp");
            }
            else
            {
                TempData["message"] = "Error Ocured Try again";
                return View(Emp);
            }
            
        }
    }
}