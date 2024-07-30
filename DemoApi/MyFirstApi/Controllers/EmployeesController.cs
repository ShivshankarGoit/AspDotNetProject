using MyFirstApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstApi.Controllers
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
        //Get:api/Employees
        public List<Employee> Get()
        {
            return EmployeesList;
        }
        //Get:api/Employees
        public Employee Get(int id)
        {
            return EmployeesList.FirstOrDefault(e=>e.Id==id);
        }
    }
}
