using EF_Store.Data.Contracts;
using EF_Store.Domain;
using StorePhone.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorePhone.Service
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
        }

        public void AddProduct(Product product)
        {
            _dbContext.Products.Create(product);
            _dbContext.Save();
        }

        public void DeleteProduct(int id)
        {
            _dbContext.Products.Delete(id);
            _dbContext.Save();
        }

        public Product GetProduct(int id)
        {
            return _dbContext.Products.Get(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.Get();
        }
    }
}