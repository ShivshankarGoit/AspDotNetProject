using DemoAPi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPi.Data
{
    public class ContactApiDbContext : DbContext
    {
        public ContactApiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact>Contacts { get; set; }
    }
}
