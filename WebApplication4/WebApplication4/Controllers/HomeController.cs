using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
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
            ViewBag.Message = "Student view";
            CollageEntities db = new CollageEntities();
            List<Student> stu_list = db.Student.ToList();
            StudentViewModel sev = new StudentViewModel();
            List<StudentViewModel> svm_list = stu_list.Select(x => new StudentViewModel
            {
                std_id = x.std_id,
                std_name = x.std_name,
                std_contact = x.std_contact,
                std_age = x.std_age,
                ad_name = x.Adminn.ad_name


            }).ToList();

             return View(svm_list);
        }
    }
}