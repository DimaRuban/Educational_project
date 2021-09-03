using EF_Store.Data;
using EF_Store.Domain;
using System.Collections.Generic;
namespace EF_Store.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new DataContext();
            var unitOfWork = new UnitOfWork(dbContext);
          
            dbContext.Database.EnsureCreated();

            var productList = new List<Product> {

            new Product {  Name = "Iphone 11", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 256 }, Description = "Text", Price = 20000, Provider = new Provider { Name = "Apple.ua" } },
            new Product {  Name = "Iphone 11 Pro", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 27000, Provider = new Provider { Name = "Apple.ua" } },
            new Product {  Name = "Iphone 12", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "White" }, MemorySize = new MemorySize { Size = 512 }, Description = "Text", Price = 30000, Provider = new Provider { Name = "ЭплМания" } },
            new Product {  Name = "Iphone 12 Pro", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 29000, Provider = new Provider { Name = "Sota.ua" } },
            new Product {  Name = "Iphone 12 Pro Max", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 35000, Provider = new Provider { Name = "Citrus.ua" } },
            new Product {  Name = "Galaxy S20", Category = new Category { Name = "Samsung" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 19000, Provider = new Provider { Name = "Citrus.ua" } },
            new Product {  Name = "Galaxy S21", Category = new Category { Name = "Samsung" }, Color = new Color { Name = "White" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 30000, Provider = new Provider { Name = "Samsung Ukraine" } },
            new Product {  Name = "Galaxy S21 Plus", Category = new Category { Name = "Samsung" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 35000, Provider = new Provider { Name = "Citrus.ua" } },
            new Product {  Name = "Xiaomi Mi 10", Category = new Category { Name = "Xiaomi" }, Color = new Color { Name = "Red" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 17000, Provider = new Provider { Name = "Xiaomi Ukraine" } },
            new Product {  Name = "Xiaomi Mi 11", Category = new Category { Name = "Xiaomi" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize { Size = 128 }, Description = "Text", Price = 24000, Provider = new Provider { Name = "Citrus.ua" } } };

            foreach (var product in productList)
            {
                unitOfWork.Products.CreateObject(product);
            }

            unitOfWork.Save();
        }
    }
} 