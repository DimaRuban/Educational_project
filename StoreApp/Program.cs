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

            var request = new LinqRequest(dbContext);


            Console.WriteLine("\n*****Task 1*****\n");

            foreach (var product in request.GetResultTask1())
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

            foreach (var product in request.GetResultTask3())
            {
                Console.WriteLine($"Category: {product.Item1} - {product.Item2} products");
            }

            Console.WriteLine("\n*****Task 4*****\n");

            foreach (var product in request.GetResultTask4())
            {
                Console.WriteLine($"Provider: {product.Item1} - {product.Item2} products");
            }

            Console.WriteLine("\n*****Task 5*****\n");

            foreach (var product in request.GetResultTask5_1())
            {
                Console.WriteLine($"Same product have category name - {product.Category.Name}");
            }

            Console.WriteLine();

            foreach (var product in request.GetResultTask5_2())
            {
                Console.WriteLine($"Different product - {product.Name}, with category name - {product.Category.Name}");
            }

            Console.ReadKey();
        }
       
    }
}