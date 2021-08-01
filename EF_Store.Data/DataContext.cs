using EF_Store.Domain;
using Microsoft.EntityFrameworkCore;

namespace EF_Store.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<MemorySize> MemorySizes { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = EF_StorePhone ;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasMany(p => p.Products)
                .WithMany(o => o.Orders);
        }
    }
}