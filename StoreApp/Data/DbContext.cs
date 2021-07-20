using StoreApp.Models;
using System.Collections.Generic;

namespace StoreApp.Data
{
    public class DbContext
    {
        public List<Product> Products { get; set; }

        public List<Order> Orders { get; set; }

        public List<User> Users { get; set; }

        public List<Color> Color { get; set; }

        public List<MemorySize> MemorySize { get; set; }

        public List<Provider> Providers { get; set; }

        public List<Role> Roles { get; set; }

        public DbContext()
        {
            Products = new List<Product>();
            Orders = new List<Order>();
            Users = new List<User>();
            Color = new List<Color>();
            MemorySize = new List<MemorySize>();
            Providers = new List<Provider>();
            Roles = new List<Role>();
        }
    }
}