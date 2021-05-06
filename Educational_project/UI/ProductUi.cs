using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class ProductUi:IProductUi
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
        public void AddNewProductUi()
        {
            try
            {             
                _display.PrintForDisplay("Введите название: ");
                _productController.NewProductName = Console.ReadLine();

                _display.PrintForDisplay("Введите стоимость: ");
                _productController.NewProductPrice =  decimal.Parse(Console.ReadLine());

                _display.PrintForDisplay("Введите цвет: ");
                _productController.NewProductColor = Console.ReadLine();

                _display.PrintForDisplay("Введите размер памяти: ");
                _productController.NewProductMemorySize = int.Parse(Console.ReadLine());

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
                _display.PrintForDisplay($"\nId: {product.Id}, название: {product.Name}, цена: {product.Price}, цвет: {product.Color.Name}, размер памяти:{product.MemorySize.Size}");
            }
        }
        public void InformAboutSuccessUi()
        {
            _display.PrintForDisplay("Вы успешно добавили новый продукт!");
        }
    }
}