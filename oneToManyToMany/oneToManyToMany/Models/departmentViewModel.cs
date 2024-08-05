using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oneToManyToMany.Models
{
    public class departmentViewModel
    {

        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public List<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();

    }
}