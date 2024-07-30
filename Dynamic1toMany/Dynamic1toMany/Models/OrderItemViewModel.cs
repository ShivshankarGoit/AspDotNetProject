using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dynamic1toMany.Models
{
    public class OrderItemViewModel
    {


        public int OrderItemId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}