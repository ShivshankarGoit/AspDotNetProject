﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstApi1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Boolean IsActive { get; set; }
    }
}