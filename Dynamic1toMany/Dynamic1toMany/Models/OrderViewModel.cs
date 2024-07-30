using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dynamic1toMany.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }=new List<OrderItemViewModel>();
    }
}