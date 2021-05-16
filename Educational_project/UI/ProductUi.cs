using StorePhone.Models;
using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class ProductUi:IProductUi
    {
        private readonly IDisplay _display;
        private readonly IDbContext _dbContext;
        private readonly IProductController _productController;
        private readonly Product _product;

        public ProductUi(IDisplay display, IDbContext dbContext, IProductController productController, Product product)
        {
            _display = display;
            _dbContext = dbContext;
            _productController = productController;
            _product = product;
        }
        public void AddNewProductUi()
        {
            try
            {             
                _display.PrintForDisplay("Введите название: ");
                _product.Name = Console.ReadLine();

                _display.PrintForDisplay("Введите стоимость: ");
                _product.Price =  decimal.Parse(Console.ReadLine());

                _display.PrintForDisplay("Введите цвет: ");
                _product.Color = Console.ReadLine();

                _display.PrintForDisplay("Введите размер памяти: ");
                _product.MemorySize = int.Parse(Console.ReadLine());

                _productController.AddNewProduct();
                InformAboutSuccessUi();
            }
            catch (FormatException e)
            {
                _display.PrintForDisplay(e.Message + "\n");
            }
        }
        public void PrintProductUi()
        {
            _dbContext.InitData();
            foreach (var product in _dbContext.Products)
            {
                _display.PrintForDisplay($"\nId: {product.Id}, название: {product.Name}, цена: {product.Price}, цвет: {_product.Color}, размер памяти:{_product.MemorySize}");
            }
        }
        public void InformAboutSuccessUi()
        {
            _display.PrintForDisplay("Вы успешно добавили новый продукт!");
        }
    }
}