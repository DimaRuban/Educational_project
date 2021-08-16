using StoreApp.Data;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp
{
    public class LinqRequest
    {
        private readonly DbContext _dbContext;
        public LinqRequest(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetResultTask1()
        {
            return _dbContext.Products.Select(x => x).OrderBy(x => x.Name);
        }

        public IEnumerable<(string ProviderName, string ProductName)> GetResultTask2()
        {

            var productsList = _dbContext.Products.Join(_dbContext.Providers,
                x => x.Provider.Name,
                z => z.Name,
                (x, z) => new { productName = x.Name, providerName = z.Name});
            return productsList.Select(x => (ProviderName: x.providerName, ProductName: x.productName));
        }

        public IEnumerable<Tuple<string, int>> GetResultTask3()
        {
            return _dbContext.Products.GroupBy(x => x.Category.Name).Select(x => new Tuple<string, int>(x.Key, x.Count()));
        }

        public IEnumerable<Tuple<string, int>> GetResultTask4()
        {
            return _dbContext.Products.GroupBy(x => x.Provider.Name).Select(x => new Tuple<string, int>(x.Key, x.Count())).OrderByDescending(x => x.Item2);
        }

        public IEnumerable<Product> GetResultTask5_1()
        {
            var firstProvider = _dbContext.Products.Where(x => x.Provider.Name == "Apple.ua");
            var secondProvider = _dbContext.Products.Where(x => x.Provider.Name == "Citrus.ua");

            return firstProvider.Intersect(secondProvider, new ProductComparer());
        }
        public IEnumerable<Product> GetResultTask5_2()
        {
            var firstProvider = _dbContext.Products.Where(x => x.Provider.Name == "Apple.ua");
            var secondProvider = _dbContext.Products.Where(x => x.Provider.Name == "Citrus.ua");

            var differentProductForFirstProvider = firstProvider.Except(secondProvider, new ProductComparer());
            var differentProductForSecondProvider = secondProvider.Except(firstProvider, new ProductComparer());

            var concatDifferentProduct = differentProductForFirstProvider.Concat(differentProductForSecondProvider);

            return concatDifferentProduct;
        }
    }
}