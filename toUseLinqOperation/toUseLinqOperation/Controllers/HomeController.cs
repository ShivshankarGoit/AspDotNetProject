using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using toUseLinqOperation.Models;
using toUseLinqOperation.Scripts;

namespace toUseLinqOperation.Controllers
{
    public class HomeController : Controller
    {
        ProductEntities db = new ProductEntities();
        ProductService productService = new ProductService();

        public ActionResult Index()
        {
            //var name = db.EmployeeDetails.Where(p => p.field == "MBBS" || p.field == "Engineer").ToList();
            //var name = db.EmployeeDetails.OrderBy(p=> p.Name).ToList();
            //var name = db.EmployeeDetails.OrderByDescending(p => p.Name).ThenByDescending(s => s.field).ToList();
            //var name = db.productDetails.ToList();
            // var name = db.productDetails.Where(p=>p.Category=="fruit").ToList();
            //var name = db.productDetails.Select(p => p.Category == ").ToList();
            //var name = productService.GetProductNames();
            // var name = db.productDetails.OrderBy(p=> p.Price).ToList();
            // var name = db.productDetails.Where(p => p.Price >100).ToList();
            /*var name = db.productDetails.Select(s => new {
                Name = s.Name,
                Id = s.ProductId
            }).ToList();*/
            var name = db.productDetails.OrderByDescending(p=>p.Price).Take(5).ToList();

            return View(name);
        }

        public ActionResult Details()
        {
            var name = db.productDetails.Average(p => p.Price);

            return View(name);
        }

        public ActionResult Create() {
            var specificIds = 1;

            var name = db.productDetails.Where(p => p.ProductId== specificIds).ToList();

            return View(name);
        }

        public ActionResult CheckToysCategory()
        {
            bool hasToys = db.productDetails.Any(p => p.Category == "fruit");

            return View(hasToys);
        }
    }
    
}