using StorePhone.Models;
using StorePhone.Сontracts;
using System;
using System.Linq;

namespace StorePhone.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IDbContext _dbContext;
        private readonly Product _product;
        private readonly ILogger _logger;

        public ProductController(IDbContext dbContext, Product product, ILogger logger)
        {   
            _dbContext = dbContext;
            _product = product;
            _logger = logger;
        }

        public void AddNewProduct()
        {
            int newProductId = _dbContext.Products.Max(x => x.Id)+1;

            _dbContext.Products.Add(new Product(newProductId, _product.Name, _product.Price, _product.Color, _product.MemorySize));
            _logger.Log($"{DateTime.Now} - был добавлен новый продукт, с ID = {newProductId}");
        }
    }
}