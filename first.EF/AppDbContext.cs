using First.Core.Models;
using Microsoft.EntityFrameworkCore;
namespace first.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<order> Orders { get; set; }
        public DbSet<product> Products { get; set; }
        public DbSet<productOrder> ProductOrders{ get; set; }
        public DbSet<IsDeleted> IsDeleted { get; set; }
        public DbSet<IsCreated> IsCreated { get; set; }
    }
}
