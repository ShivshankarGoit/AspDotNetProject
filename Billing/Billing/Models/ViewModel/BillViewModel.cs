using Microsoft.AspNetCore.Mvc.Rendering;

namespace Billing.Models.ViewModel
{
    public class BillViewModel
    {
        public int CustonerId { get; set; }
        public string CustonerName { get; set; }
        public PaymentType PaymentType { get; set; }

        public int ItemId { get; set; }
        public List<SelectListItem> ItemList { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public int DiscountPercentage { get; set; }

        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
