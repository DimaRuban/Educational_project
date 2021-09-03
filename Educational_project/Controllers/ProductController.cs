using StorePhone.Сontracts;
using System;
using System.Collections.Generic;
using System.Linq;
using EF_Store.Domain;
using EF_Store.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace StorePhone.Controllers
{
    public class ProductController : IProductController
    {
        private readonly UnitOfWork _dbContext;
        private readonly ILogger _logger;

        public ProductController(UnitOfWork dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductController(UnitOfWork dbContext, ILogger logger)
        {   
            _dbContext = dbContext;
            _logger = logger;
        }

        public void AddProduct(EF_Store.Domain.Product product)
        {
            //var newProductId = _dbContext.Products.Max(x => x.Id) + 1;
            _dbContext.Products.CreateObject(product);
            _dbContext.Save();
            _logger.Log($"{DateTime.Now} - был добавлен новый продукт, с ID = ");
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.GetObjects();
        }
    }
}