using CrUDoperation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CrUDoperation.Controllers
{
    public class HomeController : Controller
    {
        EmployeeEntities db=new EmployeeEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var result = db.EmployeeDetails.ToList();
            return View(result);
        }
        //Get by id
        [HttpGet]
        public ActionResult About(int? id)
        {
            if(id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(id != null) 
            {
               return View(db.EmployeeDetails.Find(id));
            }

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create ([Bind(Include = "id,Name,address,field")] EmployeeDetail employee)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeDetails.Add(employee);
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id )
        {
            var employee = db.EmployeeDetails.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeDetail employee)
        {
            if (id != employee.id)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
              db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = db.EmployeeDetails.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = db.EmployeeDetails.Find(id);
            db.Entry(employee).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}