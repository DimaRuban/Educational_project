using StorePhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhone
{
    public static class DbContext
    {
        public static List<Product> products = new List<Product>();

        public static List<Order> orders = new List<Order>();

        public static List<User> users = new List<User>();

        public static void InitData()
        {
            products.Add(new Product(1, "iphone 11", 21999, new Color { Name = "white" }, new MemorySize { Size = 512 }));
            products.Add(new Product(2, "iphone xs", 27000, new Color { Name = "black" }, new MemorySize { Size = 256 }));
            products.Add(new Product(3, "iphone 11 pro", 30000, new Color { Name = "red" }, new MemorySize { Size = 128 }));
            products.Add(new Product(4, "iphone 12", 35000, new Color { Name = "red" }, new MemorySize { Size = 128 }));
            products.Add(new Product(5, "iphone 12 pro", 35000, new Color { Name = "blue" }, new MemorySize { Size = 128 }));
        }

    }
}
