using OneToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OneToMany.Controllers
{
    public class HomeController : Controller
    {
        // GET: Authors
        studentEntities _context = new studentEntities();
        public ActionResult Index()
        {
            return View( _context.StudentDetails.ToList());
        }



        public ActionResult Create()
        {
           

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( StudentDetail student)
        {
            if (ModelState.IsValid)
            {
                _context.StudentDetails.Add(student);
                 _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(student);
        }

        public ActionResult Created()
        {
            ViewBag.StudentID = new SelectList(_context.StudentDetails, "student_id", "student_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Created(course course) {
            if (ModelState.IsValid)
            {
                _context.courses.Add(course);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }
            ViewBag.StudentID = new SelectList(_context.StudentDetails, "student_id", "student_name", course.student_id);
            return View(course);

        }



        // GET: Home/DeleteStudentAndCourses/5
        public ActionResult DeleteStudentAndCourses(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StudentDetail student = _context.StudentDetails.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        // POST: Home/DeleteStudentAndCourses/5
        [HttpPost, ActionName("DeleteStudentAndCourses")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudentAndCoursesConfirmed(int id)
        {
            StudentDetail student = _context.StudentDetails.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            // Delete all courses associated with the student
            // foreach (var course in student.courses.ToList())
            // {
            //   _context.courses.Remove(course);
            // }
            _context.courses.RemoveRange(student.courses.ToList());
            // Remove the student itself
            _context.StudentDetails.Remove(student);

            // Save changes to the database
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

