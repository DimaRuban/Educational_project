using StorePhone.Models;
using StorePhone.Data;
using StorePhone.UI;
using StorePhone.Сontracts;
using System;

namespace StorePhone.Controllers
{
    public class ProductController
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger _logger;

        public ProductController(IDbContext dbContext, ILogger logger)
        {   
            _dbContext = dbContext;
            _logger = logger;
        }

        public  void AddNewProduct()
        {         
            try {

                int newProductId = _dbContext.products.Count + 1;
           
                _logger.PrintForDisplay("Введите название: ");
                string newProductName = Console.ReadLine();

                _logger.PrintForDisplay("Введите стоимость: ");
                decimal newProductPrice = int.Parse(Console.ReadLine());

                _logger.PrintForDisplay("Введите цвет: ");
                string newProductColor = Console.ReadLine();

                _logger.PrintForDisplay("Введите размер памяти: ");
                int newProductMemorySize = int.Parse(Console.ReadLine());
                
                _dbContext.products.Add(new Product(newProductId, newProductName, newProductPrice, new Color { Name = newProductColor }, new MemorySize { Size = newProductMemorySize }));
                _logger.PrintForDisplay("Вы успешно добавили новый продукт!");
            }
            catch (FormatException e)
            {
                 _logger.PrintForDisplay(e.Message + "\n");
                Menu.GetMenu();
            }
        }
        public void PrintProduct()
        {
            _dbContext.InitData();
            foreach (var product in _dbContext.products)
            {
                _logger.PrintForDisplay($"\nId: {product.Id}, название: {product.Name}, цена: {product.Price}, цвет: {product.Color.Name}, размер памяти:{product.MemorySize.Size}");
            }
        }
    }
}
