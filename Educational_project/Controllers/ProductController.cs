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
        private readonly ICacheService _cacheService;
        delegate void CacheDelegate(Product product);

        public ProductController(IDbContext dbContext, ILogger logger, ICacheService cacheService)
        {   
            _dbContext = dbContext;
            _logger = logger;
            _cacheService = cacheService;
        }

        public void AddProduct(string name, decimal price, string color, int memorySize)
        {
            var newProductId = _dbContext.Products.Max(x => x.Id) + 1;

            _dbContext.Products.Add(new Product(newProductId, name, price, color, memorySize));
            _dbContext.Save();
            _logger.Log($"{DateTime.Now} - был добавлен новый продукт, с ID = {newProductId}");
            CacheDelegate cacheDelegate = _cacheService.Set();
        }
    }
}