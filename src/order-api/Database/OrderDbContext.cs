using Microsoft.EntityFrameworkCore;
using OrderAPI.Entities;

namespace OrderAPI.Database
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}
