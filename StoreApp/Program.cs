using System;
using System.Collections.Generic;
using StoreApp.Data;
using StoreApp.Models;
using System.Linq;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new DbContext();
            dbContext.InitData();

            Console.WriteLine("\n*****Task 1*****\n");

            var productList1 = dbContext.Products.Select(x => x).OrderBy(x => x.Name);
            foreach (var product in productList1)
            {
                Console.WriteLine($"Product: {product.Name}");
            }

            Console.WriteLine("\n*****Task 2*****\n");

            var productList2 = dbContext.Products.Select(x => new { providerName = x.Provider.Name, productName = x.Name });
            foreach (var product in productList2)
            {
                Console.WriteLine($"Provider - {product.providerName}, Product - {product.productName}");
            }

            Console.WriteLine("\n*****Task 3*****\n");

            var productList3 = dbContext.Products.GroupBy(x => x.Category.Name).Select(x => new { categoryName = x.Key, count = x.Count() });
            foreach (var product in productList3)
            {
                Console.WriteLine($"Category: {product.categoryName} - {product.count} products");
            }

            Console.WriteLine("\n*****Task 4*****\n");

            var productList4 = dbContext.Products.GroupBy(x => x.Provider.Name).Select(x => new { providerName = x.Key, count = x.Count() }).OrderByDescending(x => x.count);
            foreach (var product in productList4)
            {
                Console.WriteLine($"Provider: {product.providerName} - {product.count} products");
            }

            Console.WriteLine("\n*****Task 5*****\n");

            var firstProvider = dbContext.Products.Where(x => x.Provider.Name == "Apple.ua");
            var secondProvider = dbContext.Products.Where(x => x.Provider.Name == "Citrus.ua");

            var sameProduct = firstProvider.Intersect(secondProvider, new ProductComparer());

            var differentProductForFirstProvider = firstProvider.Except(secondProvider, new ProductComparer());
            var differentProductForSecondProvider = secondProvider.Except(firstProvider, new ProductComparer());

            var concatDifferentProduct = differentProductForFirstProvider.Concat(differentProductForSecondProvider);

            foreach (var product in sameProduct)
            {
                Console.WriteLine($"Same product have category name - {product.Category.Name}");
            }

            Console.WriteLine();

            foreach (var product in concatDifferentProduct)
            {
                Console.WriteLine($"Different product - {product.Name}, with category name - {product.Category.Name}");
            }
            Console.ReadKey();
        }
    }
}