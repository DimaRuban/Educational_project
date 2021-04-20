using StorePhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhone
{
     public static class ProductController
    {
       public static List<Product> products = new List<Product>();

        static ProductController()
        {
            products.Add(new Product(1, "iphone 11", 21999, new Color { Name = "white" }, new MemorySize { Size = 512 }));
            products.Add(new Product(2, "iphone xs", 27000, new Color { Name = "black" }, new MemorySize { Size = 256 }));
            products.Add(new Product(3, "iphone 11 pro", 30000, new Color { Name = "red" }, new MemorySize { Size = 128 }));
            products.Add(new Product(4, "iphone 12", 35000, new Color { Name = "red" }, new MemorySize { Size = 128 }));
            products.Add(new Product(5, "iphone 12 pro", 35000, new Color { Name = "blue" }, new MemorySize { Size = 128 }));
        }

        public static void AddNewProduct()
        {
            try {

                int newProductId = products.Count + 1;

                Console.Write("Введите название: ");
                string newProductName = Console.ReadLine();

                Console.Write("Введите стоимость: ");
                decimal newProductPrice = int.Parse(Console.ReadLine());

                Console.Write("Введите цвет: ");
                string newProductColor = Console.ReadLine();

                Console.Write("Введите размер памяти: ");
                int newProductMemorySize = int.Parse(Console.ReadLine());

                products.Add(new Product(newProductId, newProductName, newProductPrice, new Color { Name = newProductColor }, new MemorySize { Size = newProductMemorySize }));
                Console.WriteLine("Вы успешно добавили новый продукт!");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + "\n");
                Menu.GetMenu();
            }
        }

        public static void PrintProduct()
        {
            foreach (var product in products)
            {
               Console.WriteLine($"Id: {product.Id}, название: {product.Name}, цена: {product.Price}, цвет: {product.Color.Name}, размер памяти:{product.MemorySize.Size}");
            }
        }
    }
}
