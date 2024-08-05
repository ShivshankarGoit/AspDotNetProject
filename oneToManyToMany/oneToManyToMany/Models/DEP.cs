using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace oneToManyToMany.Models
{
    public class DepartmentViewModel
    {
        public string Name { get; set; } // Department Name

        // A list of employees within the department
        public List<employeeViewModel> Employees { get; set; } = new List<employeeViewModel>();
    }

    public class employeeViewModel
    {
        
        public string FullName { get; set; } // Employee Full Name

        // A list of projects assigned to this employee
        public List<ProjectViewModel> Projects { get; set; } = new List<ProjectViewModel>();
    }

    public class ProjectViewModel
    {
      
        public string ProjectName { get; set; } // Project Name
        public string Description { get; set; }
    }

}