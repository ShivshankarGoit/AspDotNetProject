using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Student()
        {
            ViewBag.Message = "Student Detail...";
            List<string> list = new List<string>();
            list.Add("Shiv");
            list.Add("ramu");
            list.Add("gauri");

            ViewBag.name = list;

            return View();
        }
    }
}