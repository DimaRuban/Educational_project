using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class ProductUi:IProductUi
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public int MemorySize { get; set; }

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
                _display.Print("Введите название: ");
                Name = Console.ReadLine();

                _display.Print("Введите стоимость: ");
                Price =  decimal.Parse(Console.ReadLine());

                _display.Print("Введите цвет: ");
                Color = Console.ReadLine();

                _display.Print("Введите размер памяти: ");
                MemorySize = int.Parse(Console.ReadLine());

                _productController.AddNewProduct(Name, Price, Color, MemorySize);

                InformAboutSuccessUi();
            }
            catch (FormatException e)
            {
                _display.Print(e.Message + "\n");
            }
        }
        public void PrintProductUi()
        {
            _dbContext.InitData();

            foreach (var product in _dbContext.Products)
            {
                _display.Print($"\nId: {product.Id}, название: {product.Name}, цена: {product.Price}, цвет: {product.Color}, размер памяти:{product.MemorySize}");
            }
        }
        public void InformAboutSuccessUi()
        {
            _display.Print("Вы успешно добавили новый продукт!");
        }
    }
}