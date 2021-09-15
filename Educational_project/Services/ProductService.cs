using EF_Store.Data.Contracts;
using EF_Store.Domain;
using StorePhone.Сontracts;
using System;
using System.Collections.Generic;

namespace StorePhone.Controllers
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _dbContext;
        private readonly ILogger _logger;

        public ProductService(IUnitOfWork dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductService(IUnitOfWork dbContext, ILogger logger)
        {   
            _dbContext = dbContext;
            _logger = logger;
        }

        public void AddProduct(string name, decimal price, string color, int memorySize)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            _dbContext.Products.CreateObject(product);
            _dbContext.Save();
        }

        public void DeleteProduct(int id)
        {
            _dbContext.Products.DeleteObject(id);
            _dbContext.Save();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.GetObjects();
        }
    }
}