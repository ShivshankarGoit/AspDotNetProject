using E_commerceAPII.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerceAPII.Data
{
    public class EcommerceContext : DbContext
    {

        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        //public DbSet<CartItem> CartItems { get; set; }
    }
}
