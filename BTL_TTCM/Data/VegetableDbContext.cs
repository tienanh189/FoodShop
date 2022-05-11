using BTL_TTCM.Models;
using Microsoft.EntityFrameworkCore;

namespace BTL_TTCM.Data
{
    public class VegetableDbContext : DbContext
    {
        public VegetableDbContext(DbContextOptions<VegetableDbContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; } 
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> ordersDetail { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Contact> contacts { get; set; }

        public DbSet<Cart> carts { get; set; }

    }
}
