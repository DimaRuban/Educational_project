using StorePhone.Models;
using System;

namespace StorePhone.Controllers
{
    public static class ProductController
    {
        public static void AddNewProduct()
        {
            try {

                int newProductId = DbContext.products.Count + 1;

                Console.Write("Введите название: ");
                string newProductName = Console.ReadLine();

                Console.Write("Введите стоимость: ");
                decimal newProductPrice = int.Parse(Console.ReadLine());

                Console.Write("Введите цвет: ");
                string newProductColor = Console.ReadLine();

                Console.Write("Введите размер памяти: ");
                int newProductMemorySize = int.Parse(Console.ReadLine());

                DbContext.products.Add(new Product(newProductId, newProductName, newProductPrice, new Color { Name = newProductColor }, new MemorySize { Size = newProductMemorySize }));
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
            foreach (var product in DbContext.products)
            {
               Console.WriteLine($"Id: {product.Id}, название: {product.Name}, цена: {product.Price}, цвет: {product.Color.Name}, размер памяти:{product.MemorySize.Size}");
            }
        }
    }
}
