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
using oneToManyToMany.Models;

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
            var department = _context.Departments
                .Include(d => d.Employees.Select(e => e.Projects))
                .FirstOrDefault(d => d.DepartmentId == id);

            if (department == null)
            {
                return HttpNotFound();
            }

            var departmentViewModel = new DepartmentViewModel
            {
                Name = department.Name,
                Employees = department.Employees.Select(e => new employeeViewModel
                {
                    FullName = e.FullName,
                    Projects = e.Projects.Select(p => new ProjectViewModel
                    {
                        ProjectName = p.ProjectName,
                        Description = p.Description
                    }).ToList()
                }).ToList()
            };

            return View(departmentViewModel);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = _context.Departments
                    .Include(d => d.Employees.Select(e => e.Projects))
                    .FirstOrDefault(d => d.DepartmentId == id);

                if (department != null)
                {
                    department.Name = model.Name;

                    // Update employees
                    foreach (var employeeModel in model.Employees)
                    {
                        var employee = department.Employees
                            .FirstOrDefault(e => e.FullName == employeeModel.FullName);

                        if (employee != null)
                        {
                            // Update projects
                            foreach (var projectModel in employeeModel.Projects)
                            {
                                var project = employee.Projects
                                    .FirstOrDefault(p => p.ProjectName == projectModel.ProjectName);

                                if (project != null)
                                {
                                    project.ProjectName = projectModel.ProjectName;
                                    project.Description = projectModel.Description;
                                }
                                else
                                {
                                    employee.Projects.Add(new Project
                                    {
                                        ProjectName = projectModel.ProjectName,
                                        Description = projectModel.Description
                                    });
                                }
                            }

                            // Remove projects not in the updated list
                            var updatedProjectNames = employeeModel.Projects.Select(p => p.ProjectName).ToList();
                            var projectsToRemove = employee.Projects.Where(p => !updatedProjectNames.Contains(p.ProjectName)).ToList();
                            foreach (var project in projectsToRemove)
                            {
                                employee.Projects.Remove(project);
                            }
                        }
                        else
                        {
                            // Add new employee with projects
                            department.Employees.Add(new Employee
                            {
                                FullName = employeeModel.FullName,
                                Projects = employeeModel.Projects.Select(p => new Project
                                {
                                    ProjectName = p.ProjectName,
                                    Description = p.Description
                                }).ToList()
                            });
                        }
                    }

                    // Remove employees not in the updated list
                    var updatedEmployeeNames = model.Employees.Select(e => e.FullName).ToList();
                    var employeesToRemove = department.Employees.Where(e => !updatedEmployeeNames.Contains(e.FullName)).ToList();
                    foreach (var employee in employeesToRemove)
                    {
                        department.Employees.Remove(employee);
                    }

                    _context.Entry(department).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index1");
                }
            }

            return View(model);
        }



    }
}