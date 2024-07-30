using OneToManyDynamic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneToManyDynamic.Controllers
{
    public class HomeController : Controller
    {
        studentEntities db =  new studentEntities();
        public ActionResult Index()
        {     
            var emp = db.Products.ToList();
            return View(emp);
        }

          public ActionResult Create()
        {
            var product = new Product();
            return View(product);
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(product);
        }
        public ActionResult Edit(int? id)
        {
            var employee = db.Products.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Product employee)
        {
            

            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        public ActionResult Delete(int Id)
        {
            var employee = db.Products.Find(Id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            var employee = db.Products.Find(Id);
            db.Entry(employee).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}