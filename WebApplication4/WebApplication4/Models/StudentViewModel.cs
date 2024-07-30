using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class StudentViewModel
    {
        public int std_id { get; set; }
        public string std_name { get; set; }
        public string std_contact { get; set; }
        public string std_age { get; set; }
        public Nullable<int> ad_id_fk { get; set; }

        public string ad_name { get; set;}
    }
}