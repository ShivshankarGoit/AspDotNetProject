using FileUploadOneToMany.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FileUploadOneToMany.Controllers
{
    public class HomeController : Controller
    {

        ProductionEntities db = new ProductionEntities();
        public ActionResult Index()
        {

            return View(db.Products.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

       // POST: Children/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create( HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("File", "Please upload a file.");
                return View();
            }

            var parent =  db.Products.Find(Id);

            if (parent == null)
            {
                return HttpNotFound();
            }


            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);
            file.SaveAs(filePath);

            var ProductFile = new ProductFile
            {
                ProductId = Id,
                ImagePath = filePath,
                
            };

             db.SaveChanges();
            return RedirectToAction("Index");

            
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
    }
}