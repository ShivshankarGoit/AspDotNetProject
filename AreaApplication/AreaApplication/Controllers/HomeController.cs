using AreaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaApplication.Controllers
{
    public class HomeController : Controller
    {
        ExcellEntities2 db = new ExcellEntities2 ();
        public ActionResult Index()
        {
            return View(db.excellSheets.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(db.excellSheets.ToList());
        }

        public ActionResult RedirectArea(long id)
        {
            if(id == 1)
            {
                return RedirectToAction("Index", "Database", new { area = "DatabaseToExcell" });
            }
            else if(id == 2)
            {
                return RedirectToAction("Index", "Excel", new { area = "ExceltoDatabase" });
            }
            return RedirectToAction("About");
        }
    }
}