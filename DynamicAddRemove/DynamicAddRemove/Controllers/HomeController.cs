using DynamicAddRemove.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicAddRemove.Controllers
{
    public class HomeController : Controller
    {
        private Employee_sEntities _context = new Employee_sEntities();

        public ActionResult Index()
        {
            var userProfiles = _context.Employees.ToList();
            return View(userProfiles);
        }



        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<Employee> employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.AddRange(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult MultipleEdit()
        {
            var employeelist = _context.Employees.ToList();
            return View(employeelist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMultipleEdit(List<Employee> Employee)
        {
            var employeelist = _context.Employees.ToList();
            foreach (var emp in Employee)
            {
                var old_data = employeelist.FirstOrDefault(z => z.EmployeeId == emp.EmployeeId);
                old_data.State = emp.State;
                _context.Entry(old_data).State = EntityState.Modified;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        /* public ActionResult Update(int? id)
         {
             var employee = _context.Employees.Find(id);
             if (employee == null)
             {
                 return HttpNotFound();
             }
             return View(employee);
         }
         [HttpPost]

         public JsonResult Update(Employee employee)
         {
             //var data = _context.Employees.Find(emp);
             try
             {
                 if (ModelState.IsValid)
                 {
                     _context.Entry(employee).State = EntityState.Modified;
                     _context.SaveChanges();
                     return Json(new { success = true });
                 }
                 return Json(new { success = false, message = "Invalid data." });
             }
             catch (DbUpdateConcurrencyException)
             {
                 return Json(new { success = false, message = "Concurrency conflict occurred." });
             }
         }

         public ActionResult Delete(int id)
         {
             var employee = _context.Employees.Find(id);
             if (employee == null)
             {
                 return HttpNotFound();
             }

             return View(employee);
         }
         [HttpPost]
         public JsonResult Delete(int? id)
         {
             try
             {
                 var employee = _context.Employees.Find(id);
                 if (employee == null)
                 {
                     return Json(new { success = false, message = "Employee not found." });
                 }

                 _context.Employees.Remove(employee);
                 _context.SaveChanges();
                 return Json(new { success = true });
             }
             catch (DbUpdateConcurrencyException)
             {
                 return Json(new { success = false, message = "Concurrency conflict occurred." });
             }
         }*/


        public ActionResult MultipleDelete()
        {
            var employeelist = _context.Employees.ToList();
            return View(employeelist);
        }

        [HttpPost, ActionName("MultipleDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult MultipleDelete(List<int> EmployeeId)
        {
            if (EmployeeId != null)
            {
                foreach (var id in EmployeeId)
                {
                    var employee = _context.Employees.Find(id);
                    if (employee != null)
                    {
                        _context.Employees.Remove(employee);
                    }
                }
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}