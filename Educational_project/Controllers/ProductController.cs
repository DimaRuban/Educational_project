using StorePhone.Logging;
using StorePhone.Models;
using StorePhone.Сontracts;
using System;
using System.Linq;

namespace StorePhone.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly ISerializer _serializer;

        public ProductController(IDbContext dbContext, ILogger logger,ISerializer serializer)
        {   
            _dbContext = dbContext;
            _logger = logger;
            _serializer = serializer;
        }

        public void AddNewProduct(string name, decimal price, string color, int memorySize)
        {
            int newProductId = _dbContext.Products.Max(x => x.Id) + 1;

            _dbContext.Products.Add(new Product(newProductId, name, price, color, memorySize));
            _serializer.SerializeProducts();
            _logger.Log($"{DateTime.Now} - был добавлен новый продукт, с ID = {newProductId}");
        }
    }
}