using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class ProductUi:IProductUi
    {
        public string NewProductName { get; set; }

        public decimal NewProductPrice { get; set; }

        public string NewProductColor { get; set; }

        public int NewProductMemorySize { get; set; }


        private readonly IDisplay _display;
        private readonly IDbContext _dbContext;
        public ProductUi(IDisplay display, IDbContext dbContext)
        {
            _display = display;
            _dbContext = dbContext;
        }
        public void AddNewProductUi()
        {   
            try
            {             
                _display.PrintForDisplay("Введите название: ");
                NewProductName = Console.ReadLine();

                _display.PrintForDisplay("Введите стоимость: ");
                NewProductPrice =  decimal.Parse(Console.ReadLine());

                _display.PrintForDisplay("Введите цвет: ");
                NewProductColor = Console.ReadLine();

                _display.PrintForDisplay("Введите размер памяти: ");
                NewProductMemorySize = int.Parse(Console.ReadLine());                
            }
            catch (FormatException e)
            {
                _display.PrintForDisplay(e.Message + "\n");
            }
        }
        public void PrintProductUi()
        {
            foreach (var product in _dbContext.Products)
            {
                _display.PrintForDisplay($"\nId: {product.Id}, название: {product.Name}, цена: {product.Price}, цвет: {product.Color.Name}, размер памяти:{product.MemorySize.Size}");
            }
        }
        public void InformAboutSuccess()
        {
            _display.PrintForDisplay("Вы успешно добавили новый продукт!");
        }
    }
}
