using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        [Required (ErrorMessage =  "Please enter your name.") ]
        public string StudentName { get; set; }
        public  Age StudentAge{ get; set; }
        public bool isActive { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }

        public string Description { get; set; }
    }

    public enum Age
    {
        Child=1,
        Adult=2 ,
        Old=3
    }
}