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

        public void InitData()
        {
            Products.Add(new Product { Id = 1, Name = "Iphone 11", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 256 }, Description = "Text", Price = 20000, Provider = new Provider { Name = "Apple.ua" } });
            Products.Add(new Product { Id = 2, Name = "Iphone 11 Pro", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 27000, Provider = new Provider { Name = "Apple.ua" } });
            Products.Add(new Product { Id = 3, Name = "Iphone 12", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "White" }, MemorySize = new MemorySize { Size = 512 }, Description = "Text", Price = 30000, Provider = new Provider { Name = "ЭплМания" } });
            Products.Add(new Product { Id = 4, Name = "Iphone 12 Pro", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 29000, Provider = new Provider { Name = "Sota.ua" } });
            Products.Add(new Product { Id = 5, Name = "Iphone 12 Pro Max", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 35000, Provider = new Provider { Name = "Citrus.ua" } });
            Products.Add(new Product { Id = 6, Name = "Galaxy S20", Category = new Category { Name = "Samsung" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 19000, Provider = new Provider { Name = "Citrus.ua" } });
            Products.Add(new Product { Id = 7, Name = "Galaxy S21", Category = new Category { Name = "Samsung" }, Color = new Color { Name = "White" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 30000, Provider = new Provider { Name = "Samsung Ukraine" } });
            Products.Add(new Product { Id = 8, Name = "Galaxy S21 Plus", Category = new Category { Name = "Samsung" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 35000, Provider = new Provider { Name = "Citrus.ua" } });
            Products.Add(new Product { Id = 9, Name = "Xiaomi Mi 10", Category = new Category { Name = "Xiaomi" }, Color = new Color { Name = "Red" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 17000, Provider = new Provider { Name = "Xiaomi Ukraine" } });
            Products.Add(new Product { Id = 10, Name = "Xiaomi Mi 11", Category = new Category { Name = "Xiaomi" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price =24000, Provider = new Provider { Name = "Citrus.ua" } });
        }
    }
}