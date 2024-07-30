using Final.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly UpploadEntities _context = new UpploadEntities();

       

        [HttpGet]
        public ActionResult Upload()
        {
            return View("UploadImage");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    var imageData = binaryReader.ReadBytes(file.ContentLength);
                    var image = new Image
                    {
                        ImageName = Path.GetFileName(file.FileName),
                        ImageData = imageData
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var images = _context.Images.ToList();
            return View(images);
        }

        public ActionResult GetImage(int id)
        {
            var image = _context.Images.Find(id);
            if (image != null)
            {
                return File(image.ImageData, "image/jpeg"); // or "image/png" based on the image type
            }
            return HttpNotFound();
        }
    }
}