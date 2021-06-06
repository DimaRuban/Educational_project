using StorePhone.Controllers;
using StorePhone.Data;
using StorePhone.Logging;
using StorePhone.UI;
using StorePhone.Validation;

namespace EducationalProject
{
    class Program
    {
        static void Main(string[] args)
        {   
            var display = new Display();
            var dbContext = new DbContext();

            var validator = new Validator();

            var fileManager = new FileManager();

            var logger = new Logger(fileManager);
           
            var productController = new ProductController(dbContext, logger);
            var orderController = new OrderController(dbContext, logger);
            var accountController = new AccountController(dbContext, logger);
           
            var productUi = new ProductUi(display, dbContext, productController);
            var orderUi = new OrderUi(display, orderController, productUi, validator);
            var accountUi = new AccountUi(display,accountController, validator);

            var menu = new Menu(productUi, orderUi, accountUi, display);

            dbContext.InitData();

            display.Print("Здравствуйте! Вас приветствует магазин Store Phone!\n");
            while (true)
            {
                menu.GetMenu();         
            }
        }
    }
}