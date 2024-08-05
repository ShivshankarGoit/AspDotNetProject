using oneToManyToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace oneToManyToMany.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDBEntities2 _Context = new CompanyDBEntities2();
        // GET: Employee
        public ActionResult Index()
        {
            var emp = _Context.Departments.ToList();
            return View(emp);
        }
        // GET: Orders/Create
        public ActionResult Create()
        {
            var model = new departmentViewModel();
            return View(model);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(departmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = _Context.Departments.FirstOrDefault(x => x.Name == model.Name);

                if (department == null)
                {
                    department = new Department
                    {
                        Name = model.Name,
                        Employees = model.Employees.Select(i => new Employee
                        {
                            FullName = i.FullName

                        }).ToList()
                    };
                    _Context.Departments.Add(department);
                }
                else
                {
                    department.Employees = model.Employees.Select(i => new Employee
                    {
                        FullName = i.FullName

                    }).ToList();
                    _Context.Entry(department).State = System.Data.Entity.EntityState.Modified;
                }

                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        // Action to get employees by department ID
     
        public JsonResult GetEmployeesByDepartment(long? departmentId)
        {
            var employee = _Context.Employees.Where(x => x.DepartmentId == departmentId).ToList();

            if (employee == null)
            {
                return Json(new
                {
                    Success = false,
                },
                JsonRequestBehavior.AllowGet);
            }

            var dataList = employee.Select(x => new { DisplayField = x.FullName, BindField = x.EmployeeId.ToString() }).ToList();
            return Json(dataList.Distinct().ToList(), JsonRequestBehavior.AllowGet);

        }
        // GET: Employee/AddProject
        public ActionResult AddProject(int id)
        {
            var employees = _Context.Employees
                           .Where(x => x.DepartmentId == id)
                           .Select(e => new EmployeeViewModel
                           {
                               EmployeeId = e.EmployeeId,
                               FullName = e.FullName
                           }).ToList();
            ViewBag.DepartmentId = id;
            return View(employees);
        }
        // POST: Employee/AddProject
        [HttpPost]
        public ActionResult AddProject(int employeeId, string projectName)
        {
            if (ModelState.IsValid)
            {
                var project = new Project
                {
                    ProjectName = projectName,
                    EmployeeId = employeeId
                };

                _Context.Projects.Add(project);
                _Context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        // GET: Departments/Edit/5
      

        


    }
}