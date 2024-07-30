using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HamroMaat.Models.View_Models
{
    public class Catagory
    {

        public int cat_id { get; set; }
        public string cat_name { get; set; }
        public string cat_color { get; set; }
        public string cat_icon { get; set; }
        public Nullable<System.DateTime> cat_create_done { get; set; }
        public Nullable<int> cat_fk_Ad_id { get; set; }
    }
}