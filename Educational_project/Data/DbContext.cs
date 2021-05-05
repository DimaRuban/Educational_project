using StorePhone.Models;
using StorePhone.Сontracts;
using System.Collections.Generic;

namespace StorePhone.Data
{
    public  class DbContext : IDbContext
    {
        public List<Product> Products { get; set; }

        public List<Order> Orders { get; set; }

        public List<User> Users { get; set; }

        public DbContext()
        {
            Products = new List<Product>();
            Orders = new List<Order>();
            Users = new List<User>();
        }
        public  void InitData()
        {
            Products.Add(new Product(1, "iphone 11", 21999, new Color { Name = "white" }, new MemorySize { Size = 512 }));
            Products.Add(new Product(2, "iphone xs", 27000, new Color { Name = "black" }, new MemorySize { Size = 256 }));
            Products.Add(new Product(3, "iphone 11 pro", 30000, new Color { Name = "red" }, new MemorySize { Size = 128 }));
            Products.Add(new Product(4, "iphone 12", 35000, new Color { Name = "red" }, new MemorySize { Size = 128 }));
            Products.Add(new Product(5, "iphone 12 pro", 35000, new Color { Name = "blue" }, new MemorySize { Size = 128 }));
        }
    }
}
