﻿using Newtonsoft.Json;
using StorePhone.Models;
using StorePhone.Сontracts;
using System.Collections.Generic;
using System.IO;

namespace StorePhone.Logging
{
    public class Serializer : ISerializer
    {
        private readonly IFileManager _fileManager;
        private readonly IDbContext _dbContext;

        private string directoryPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Store Phone system files" + Path.DirectorySeparatorChar;

        public Serializer(IFileManager fileManager,IDbContext dbContext)
        {
            _fileManager = fileManager;
            _dbContext = dbContext;
        }

        public void SerializeProducts()
        {
            var serialized = JsonConvert.SerializeObject(_dbContext.Products);
            _fileManager.WorkWithSerializationFileProducts(serialized);
        }

        public void SerializeOrders()
        {
            var serialized = JsonConvert.SerializeObject(_dbContext.Orders);
            _fileManager.WorkWithSerializationFileOrders(serialized);
        }

        public void SerializeUsers()
        {
            var serialized = JsonConvert.SerializeObject(_dbContext.Users);
            _fileManager.WorkWithSerializationFileUsers(serialized);
        }

        public void DeserializeProducts()
        {
            var serializationProductsPath = directoryPath + "Serialization Products.txt";

            var products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(serializationProductsPath));

            foreach (var product in products)
            {
                _dbContext.Products.Add(new Product(product.Id, product.Name, product.Price, product.Color, product.MemorySize));
            }
        }

        public void DeserializeOrders()
        {
            var serializationOrdersPath = directoryPath + "Serialization Orders.txt";

            var orders = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(serializationOrdersPath));

            foreach (var order in orders)
            {
                _dbContext.Orders.Add(new Order(order.Id, order.CreatedAt, order.UserName, order.PhoneNumber, order.Address, order.Quantity, order.TotalPrice));
            }
        }

        public void DeserializeUsers()
        {
            var serializationUsersPath = directoryPath + "Serialization Users.txt";

            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(serializationUsersPath));
       
            foreach (var user in users)
            {
                _dbContext.Users.Add(new User(user.Id, user.FirstName, user.LastName, user.EmailAddress, user.PhoneNumber, user.UserName, user.Password, user.Role));
            }
        }
    }
}