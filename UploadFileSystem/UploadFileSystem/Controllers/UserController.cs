using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UploadFileSystem.Models;

namespace UploadFileSystem.Controllers
{
    public class UserController : Controller
    {
        private ProductionEntities db = new ProductionEntities();
        // GET: User
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // Add this method to UserController

        // GET: User/Upload/5
        public ActionResult Upload(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(int? id, HttpPostedFileBase file)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (file != null && file.ContentLength > 0)
            {
                var user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                // Ensure the Uploads directory exists
                string uploadDir = Server.MapPath("~/Uploads");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                // Generate a unique file name to avoid conflicts
                string fileName = Path.GetFileName(file.FileName);
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                string path = Path.Combine(uploadDir, uniqueFileName);

                // Save the file
                file.SaveAs(path);

                UserFile userFile = new UserFile
                {
                    FileName = fileName,
                    FilePath = "~/Uploads/" + uniqueFileName, // Store relative path
                    UserId = user.Id
                };

                db.UserFiles.Add(userFile);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.UserId = id;
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user, List<HttpPostedFileBase> file)
        {

            var userFi = db.Users.Find(id);
            if (userFi == null)
            {
                return HttpNotFound();
            }
            if (user.UserFiles != null)
            {

                // Ensure the Uploads directory exists
                string uploadDir = Server.MapPath("~/Uploads");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                foreach (var i in user.UserFiles.Where(x => x.httpPostedFileBases != null))
                {
                    var userfile = db.UserFiles.Find(i.Id);
                    if (userfile == null)
                    {
                        return HttpNotFound();
                    }
                    // Generate a unique file name to avoid conflicts
                    string fileName = Path.GetFileName(i.httpPostedFileBases.FileName);
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                    string path = Path.Combine(uploadDir, uniqueFileName);

                    i.httpPostedFileBases.SaveAs(path);

                    string oldFilePath = uploadDir + "/" + i.FileName;
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }

                    // Update the user file
                    userfile.FileName = fileName;
                    userfile.FilePath = "~/Uploads/" + uniqueFileName;
                    db.Entry(userfile).State = EntityState.Modified;
                }
                userFi.Name = user.Name;        
               db.Entry(userFi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

                // Save the file

            }



            return View(user);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            

            // Delete associated files if they exist
            foreach (var file in user.UserFiles.ToList())
            {
                string filePath = Server.MapPath(file.FilePath);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                db.UserFiles.Remove(file);
            }

            // Delete user record
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }






}
