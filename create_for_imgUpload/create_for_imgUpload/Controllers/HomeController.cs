using create_for_imgUpload.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace create_for_imgUpload.Controllers
{
    public class HomeController : Controller
    {      
              UpploadEntities db = new UpploadEntities();
            public ActionResult Index()
             {
                return View();
             }
             

            [HttpPost]
            public ActionResult UploadImage( )
            {
                string message = "";

                // Check if the request is a POST request
                if (Request.HttpMethod == "POST")
                {
                    // Retrieve the title from the request
                    var title = Request["title"];

                    // Retrieve the uploaded file
                    var file = Request.Files["file"];

                    // Check if the file is not null and has content
                    if (file != null && file.ContentLength > 0)
                    {
                        // Get the file name and the path to save it
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                        // Save the file to the server
                        file.SaveAs(path);

                        // Create a new Image object and save it to the database
                        var image = new Models.File { FileName = title, Path = "/Images/" + fileName };
                        db.Files.Add(image);
                        db.SaveChanges();

                        // Set the success message
                        message = "Image uploaded successfully!";
                    }
                    else
                    {
                        // Set the error message if no file was uploaded
                        message = "No file uploaded.";
                    }
                }

                // Optionally, you can pass the message to the view
                ViewBag.Message = message;
                return View();
            }


         

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}