using Newtonsoft.Json;
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

        private string _directoryPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Store Phone system files" + Path.DirectorySeparatorChar;

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
        public void DeSerializeProducts()
        {
            var serializationProductsPath = _directoryPath + "Serialization Products.txt";

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(serializationProductsPath));

            foreach (var item in products)
            {
                _dbContext.Products.Add(new Product(item.Id, item.Name, item.Price, item.Color, item.MemorySize));
            }
        }
        public void DeSerializeOrders()
        {
            var serializationOrdersPath = _directoryPath + "Serialization Orders.txt";

            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(serializationOrdersPath));

            foreach (var item in orders)
            {
                _dbContext.Orders.Add(new Order(item.Id,item.CreatedAt,item.UserName,item.PhoneNumber,item.Address,item.Quantity,item.TotalPrice));
            }
        }
        public void DeSerializeUsers()
        {
            var serializationUsersPath = _directoryPath + "Serialization Users.txt";

            List<User> users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(serializationUsersPath));
       
            foreach (var item in users)
            {
                _dbContext.Users.Add(new User(item.Id, item.FirstName,item.LastName,item.EmailAddress,item.PhoneNumber,item.UserName,item.Password,item.Role));
            }
        }
    }
}