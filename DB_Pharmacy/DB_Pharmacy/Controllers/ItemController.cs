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

    public class ItemController : Controller
    {
        // GET: Medicine
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Addmed()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addmed(Itemmodel Item)
        {

            if (ModelState.IsValid)
            {
                Itemmanager obj = new Itemmanager();
                int check = obj.Addmed(Item);
                if (check > 0)
                {
                    TempData["message"] = "Data Inserted your ItemID: " + check;
                    return RedirectToAction("Stockmed");
                }
                else
                {
                    TempData["message"] = "Enter Item to be Inserted";
                    return View();
                }
            }
            else
            {
                TempData["message"] = "Enter Valid Item";
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult updatemed(int ItemID)
        {
            Itemmanager obj = new Itemmanager();
            Itemmodel item = obj.Getitem(ItemID);
            return View(item);
        }

        [HttpPost]
        public ActionResult updatemed(Itemmodel item)
        {
            Itemmanager obj = new Itemmanager();
            bool check = obj.updateitem(item);
            if (check)
            {
                return RedirectToAction("Stockmed");
            }
            else
            {
                TempData["Message"] = "Some error";
                return View(item);
            }
            
        }
        public ActionResult deletemed(int ItemID)
        {
            Itemmanager obj = new Itemmanager();
            bool check = obj.deleteitem(ItemID);
            if (check)
            {
                TempData["Message"] = "data deleted successfulyl";
            }
            else
            {
                TempData["Message"] = "data dosen't delete, something wrong";
            }
            return RedirectToAction("Stockmed");
        }

        public ActionResult Stockmed()
        {
            Itemmanager obj = new Itemmanager();
            List<Itemmodel> Adminitem = obj.Getallitem();
            return View(Adminitem);
        }
    }
}