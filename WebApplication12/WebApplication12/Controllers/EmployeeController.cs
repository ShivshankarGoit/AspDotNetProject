using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee   
        //private readonly  Employee_context;

        //public MyController(MyDbContext context)
        //{
        //    _context = context;
        //}

        EmployeeEntities2 employeeEntities = new EmployeeEntities2();
        public ActionResult Test ()
        {
            Testing testing = new Testing
            {
                FirstName = " Hello",
                LastName = "Twej"
            };
            return View(testing);
        }

        public ActionResult Index()
        {
            var employeedata = employeeEntities.EmployeeDetails.ToList();
            return View(employeedata);
        }

        public ActionResult Create()
        {
           // var employeedata = employeeEntities.EmployeeDetails.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeDetail emp ) 
        {

            

            // Add the user to the database
            employeeEntities.EmployeeDetails.Add(emp);



            employeeEntities.SaveChanges();

            return View();

        }
    }
}
