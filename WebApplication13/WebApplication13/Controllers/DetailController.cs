using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail

        personalDetailEntities persondata = new personalDetailEntities();
        public ActionResult Index()
        {
            var employeedata = persondata.infoes.ToList();
            return View(employeedata);
        }

        

        public ActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Create(info Info) 
        {
            if (ModelState.IsValid)
            {
                persondata.infoes.Add(Info);
                persondata.SaveChanges();
                return RedirectToAction("Index"); // Redirect to a list of users or another appropriate action
            }

            return View(Info);
        }
    }
}