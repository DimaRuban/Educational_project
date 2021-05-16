using StorePhone.Models;
using StorePhone.Сontracts;
using System;
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
            Products.Add(new Product(1, "iphone 11", 21999, "white", 512));
            Products.Add(new Product(2, "iphone xs", 27000, "black" ,  256 ));
            Products.Add(new Product(3, "iphone 11 pro", 30000,  "red", 128 ));
            Products.Add(new Product(4, "iphone 12", 35000, "red" , 128 ));
            Products.Add(new Product(5, "iphone 12 pro", 35000, "blue", 128 ));
            Orders.Add(new Order(1, DateTime.Now, "test", "test", 1, 1));
            Users.Add(new User(1, "test", "test", "test", "test", "test", "test", new Role { Name = "test"}));
        }
    }
}