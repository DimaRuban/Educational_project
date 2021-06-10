using Newtonsoft.Json;
using StorePhone.Logging;
using StorePhone.Models;
using StorePhone.Сontracts;
using System.Collections.Generic;
using System.IO;

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

        public void Save()
        {          
            var serializedProducts = JsonConvert.SerializeObject(Products);
            FileManager.Write(serializedProducts, FileManager.GetProductsPath());

            var serializedOrders = JsonConvert.SerializeObject(Orders);
            FileManager.Write(serializedOrders, FileManager.GetOrdersPath());

            var serializedUsers = JsonConvert.SerializeObject(Users);
            FileManager.Write(serializedUsers, FileManager.GetUsersPath());
        }

        public void Init()
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(FileManager.GetProductsPath()));
            foreach (var product in products)
            {
                Products.Add(new Product(product.Id, product.Name, product.Price, product.Color, product.MemorySize));
            }

            var orders = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(FileManager.GetOrdersPath()));
            foreach (var order in orders)
            {
                Orders.Add(new Order(order.Id, order.CreatedAt, order.UserName, order.PhoneNumber, order.Address, order.Quantity, order.TotalPrice));
            }

            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(FileManager.GetUsersPath()));
            foreach (var user in users)
            {
                Users.Add(new User(user.Id, user.FirstName, user.LastName, user.EmailAddress, user.PhoneNumber, user.UserName, user.Password, user.Role));
            }         
        }
    }
}