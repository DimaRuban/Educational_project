using StorePhone.Controllers;
using StorePhone.Data;
using StorePhone.Logging;
using StorePhone.Models;
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

            var fileManager = new FileManager();

            var logger = new Logger(fileManager);

            var validator = new Validator(dbContext, display);

            var product = new Product();
            var order = new Order();
            var user = new User();

            var productController = new ProductController(dbContext, product, logger);
            var orderController = new OrderController(dbContext, order, logger);
            var accountController = new AccountController(dbContext, user, logger);
           
            var productUi = new ProductUi(display, dbContext, productController, product);
            var orderUi = new OrderUi(dbContext, display, orderController, productUi, order);
            var accountUi = new AccountUi(display,accountController, validator, user);

            var menu = new Menu(productUi, orderUi, accountUi, display);

            display.PrintForDisplay("Здравствуйте! Вас приветствует магазин Store Phone!\n");
            while (true)
            {
                menu.GetMenu();         
            }
        }
    }
}