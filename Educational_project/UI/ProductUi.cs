using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class ProductUi : IProductUi
    {
        private readonly IDisplay _display;
        private readonly IDbContext _dbContext;
        private readonly IProductController _productController;

        public ProductUi(IDisplay display, IDbContext dbContext, IProductController productController)
        {
            _display = display;
            _dbContext = dbContext;
            _productController = productController;
        }
        public void AddProductUi()
        {
            try
            {
                _display.Print("Введите название: ");
                string name = Console.ReadLine();

                _display.Print("Введите стоимость: ");
                decimal price = decimal.Parse(Console.ReadLine());

                _display.Print("Введите цвет: ");
                string color = Console.ReadLine();

                _display.Print("Введите размер памяти: ");
                int memorySize = int.Parse(Console.ReadLine());

                _productController.AddProduct(name, price, color, memorySize);

                InformAboutSuccessUi();
            }
            catch (FormatException e)
            {
                _display.Print(e.Message + "\n");
            }
        }
        public void PrintProductUi()
        {
            foreach (var product in _dbContext.Products)
            {
                _display.Print($"\nId: {product.Id}, название: {product.Name}, цена: {product.Price}, цвет: {product.Color}, размер памяти:{product.MemorySize}");
            }
        }
        private void InformAboutSuccessUi()
        {
            _display.Print("Вы успешно добавили новый продукт!");
        }
    }
}