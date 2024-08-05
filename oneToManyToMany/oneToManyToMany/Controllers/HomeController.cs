using oneToManyToMany.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace oneToManyToMany.Controllers
{
    public class HomeController : Controller
    {

        private readonly CompanyDBEntities2 _context = new CompanyDBEntities2();



        // GET: Organization
        public ActionResult Index1()
        {
            var emp = _context.Departments.ToList();
            return View(emp);
        }

        // GET: Organization/Create
        public ActionResult Create1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create1(List<DepartmentViewModel> Departments)
        {
            if (ModelState.IsValid)
            {
                foreach (var model in Departments)
                {
                    var department = _context.Departments.FirstOrDefault(x => x.Name == model.Name);

                    if (department == null)
                    {
                        department = new Department
                        {
                            Name = model.Name,
                            Employees = model.Employees.Select(e => new Employee
                            {
                                FullName = e.FullName,
                                Projects = e.Projects.Select(p => new Project
                                {
                                    ProjectName = p.ProjectName
                                }).ToList()
                            }).ToList()
                        };
                        _context.Departments.Add(department);
                    }
                    else
                    {
                        // Update the existing department's employees
                        department.Employees = model.Employees.Select(e => new Employee
                        {
                            FullName = e.FullName,
                            Projects = e.Projects.Select(p => new Project
                            {
                                ProjectName = p.ProjectName,
                                Description = p.Description
                            }).ToList()
                        }).ToList();

                        _context.Entry(department).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index1));
            }
            return View(Departments);
        }
        public ActionResult Edit(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == id);

            if (department == null)
            {
                return HttpNotFound();
            }

            var model = new DepartmentViewModel
            {

                Name = department.Name,
                Employees = department.Employees.Select(e => new employeeViewModel
                {
                    FullName = e.FullName,
                    Projects = e.Projects.Select(p => new ProjectViewModel
                    {
                        ProjectName = p.ProjectName
                    }).ToList()
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == id);

                if (department == null)
                {
                    return HttpNotFound();
                }

                department.Name = model.Name;

                // Clear existing employees and add updated ones
                department.Employees.Clear();
                foreach (var employeeModel in model.Employees)
                {
                    var employee = new Employee
                    {
                        FullName = employeeModel.FullName,
                        Projects = employeeModel.Projects.Select(p => new Project
                        {
                            ProjectName = p.ProjectName
                        }).ToList()
                    };
                    department.Employees.Add(employee);
                }

                _context.Entry(department).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index1));
            }
            return View(model);
        }


    }
}