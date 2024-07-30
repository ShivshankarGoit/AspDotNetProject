using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPage.Models;

namespace WebPage.Controllers
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

        public ActionResult StudentView()
        {
            ViewBag.Message = "Student View";
            CollageEntities  db = new CollageEntities();
            List<Student> std_list = db.Students.ToList();
            studentViewModel svm = new studentViewModel();
            List<studentViewModel>svmlist = std_list.Select(x=>new studentViewModel
            {
                std_id=x.std_id,
                std_name=x.std_name,
                std_contact=x.std_contact,
                std_age=x.std_age,
                ad_name=x.Adminn.ad_name
            }).ToList();
            return View(svmlist);
        }
    }
}