using MyFirstApi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstApi1.Controllers
{
    public class EmployeesController : ApiController
    {
        public static List<Employee> EmployeesList = new List<Employee>
        {
             new Employee {Id = 1001, Name = "Ramesh Chandra", Address = "Jaipur", IsActive = true },
                new Employee {Id = 1002, Name = "Ahmad Hasan", Address = "New Delhi", IsActive = true},
                new Employee {Id = 1003,Name = "John Doe", Address = "New York", IsActive = true },
                new Employee {Id = 1004,Name = "Mohan Kumar", Address = "Noida", IsActive = false},
                new Employee {Id = 1005,Name = "Srinivasan G", Address = "Chennai", IsActive = true}
        };
        public List<Employee> Get()
        {
            return EmployeesList;
        }
        public Employee Get(int id)
        {
            return EmployeesList.FirstOrDefault(e => e.Id == id);
        }
        public void Post(Employee employee) 
        {
            EmployeesList.Add(employee);
        }
        public void Put(int id ,Employee employee) 
        {
            var emp = EmployeesList.FirstOrDefault(e => e.Id == id);
            if(emp != null) 
            {
                emp.Name = employee.Name;
                emp.Address = employee.Address;
                emp.IsActive = employee.IsActive;
            }
        }
        public void Delete(int id)
        {
            var emp = EmployeesList.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
               EmployeesList.Remove(emp);
            }
        }
    }
}
