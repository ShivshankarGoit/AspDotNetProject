using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload

        private readonly UpploadEntities _context;

        public FileUploadController()
        {
            _context = new UpploadEntities();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string[] allowedExtensions = { ".pdf", ".doc", ".docx" };

                    if (allowedExtensions.Contains(fileExtension))
                    {
                        var maxFileSize = 5 * 1024 * 1024; // 5MB
                        if (file.ContentLength > maxFileSize)
                        {
                            ViewBag.Message = "File size exceeds the maximum limit of 5MB.";
                            return View();
                        }

                        // Save the file to the server
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                        file.SaveAs(path);

                        // Save the file path to the database
                        var fileEntity = new Models.File
                        {
                            FileName = fileName,
                            ContentType = path
                        };
                        _context.Files.Add(fileEntity);
                        _context.SaveChanges();

                        // Display success message
                        ViewBag.Message = "File uploaded successfully!";
                    }
                    else
                    {
                        ViewBag.Message = "Only pdf, doc, and docx files are allowed.";
                    }
                }
                else
                {
                    ViewBag.Message = "Please select a file to upload.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View(Index);
        }

        private ActionResult View(Func<ActionResult> index)
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            // Adjust this to match your generated DbSet property
            return View();
        }
    }
}