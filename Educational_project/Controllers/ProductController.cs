using StorePhone.Models;
using StorePhone.Сontracts;
using System;

namespace StorePhone.Controllers
{
    public class ProductController : IProductController
    {
        public string NewProductName { get; set; }
        public decimal NewProductPrice { get; set; }
        public string NewProductColor { get; set; }
        public int NewProductMemorySize { get; set; }

        private readonly IDbContext _dbContext;
        private readonly ILogger _logger;

        public ProductController(IDbContext dbContext,ILogger logger)
        {   
            _dbContext = dbContext;
            _logger = logger;
        }

        public void AddNewProduct()
        {
             int newProductId = _dbContext.Products.Count + 1;
                
            _dbContext.Products.Add(new Product(newProductId, NewProductName, NewProductPrice, new Color { Name = NewProductColor }, new MemorySize { Size = NewProductMemorySize }));
            _logger.Log($"{DateTime.Now} - был добавлен новый продукт, с ID = {newProductId}");
        }
    }
}