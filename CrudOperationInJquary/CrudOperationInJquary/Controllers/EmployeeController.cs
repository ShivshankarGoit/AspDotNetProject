using CrudOperationInJquary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CrudOperationInJquary.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private Employee_sEntities empDB = new  Employee_sEntities();

        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(empDB.Employees.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Employee emp)
        {
            return Json(empDB.Employees.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB.Employees.ToList().Find(x => x.EmployeeId.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Employee emp)
        {
             
            return Json( JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB.Employees.Remove(ID), JsonRequestBehavior.AllowGet);
        }
    }
}
