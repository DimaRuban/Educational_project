using StorePhone.Models;
using StorePhone.Сontracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorePhone.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger _logger;

        public ProductController(IDbContext dbContext, ILogger logger)
        {   
            _dbContext = dbContext;
            _logger = logger;
        }

        public void AddProduct(string name, decimal price, string color, int memorySize)
        {
            var newProductId = _dbContext.Products.Max(x => x.Id) + 1;

            _dbContext.Products.Add(new Product(newProductId, name, price, color, memorySize));
            _dbContext.Save();
            _logger.Log($"{DateTime.Now} - был добавлен новый продукт, с ID = {newProductId}");
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToArray().Select(x => new Product())
                    .ToList();
        }
    }
}