using StoreApp.Contracts;
using StoreApp.Models;
using System.Collections.Generic;

namespace StoreApp.Data
{
    public class DbContext : IDbContext
    {
        public List<Product> Products { get; set; }

        public List<Order> Orders { get; set; }

        public List<User> Users { get; set; }

        public List<Color> Colors { get; set; }

        public List<MemorySize> MemorySizes { get; set; }

        public List<Provider> Providers { get; set; }

        public List<Role> Roles { get; set; }

        public DbContext()
        {
            Products = new List<Product>();
            Orders = new List<Order>();
            Users = new List<User>();
            Colors = new List<Color>();
            MemorySizes = new List<MemorySize>();
            Providers = new List<Provider>();
            Roles = new List<Role>();
        }
    }
}