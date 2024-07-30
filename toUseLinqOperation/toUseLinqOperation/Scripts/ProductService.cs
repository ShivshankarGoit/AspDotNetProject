using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using toUseLinqOperation.Models;

namespace toUseLinqOperation.Scripts
{
    public class ProductService
    {
        ProductEntities db = new ProductEntities();
        public List<ProductView> GetProductNames()
        {
            return db.productDetails
                           .Select(p => new ProductView
                           {
                               Name = p.Name
                           })
                           .ToList();
        }
    }
}