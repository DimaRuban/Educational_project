using System;
using System.Collections.Generic;
using StoreApp.Data;
using StoreApp.Models;
using System.Linq;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new DbContext();

            dbContext.Products.Add(new Product { Id = 1, Name = "Iphone 11", Category = new Category { Name = "Iphone" }, Color = new Color { Name = "Black" }, MemorySize = new MemorySize {Size = 256 } ,Description = "Text", Price = 20000, Provider = new Provider { Name = "Apple.ua" } });
            
            Console.ReadKey();
        }
    }
}