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
            
            var fileManager = new FileManager();
            var dbContext = new DbContext();
            var serializer = new Serializer(fileManager,dbContext);

            var logger = new Logger(fileManager);

            var validator = new Validator(dbContext, display);

            var productController = new ProductController(dbContext, logger,serializer);
            var orderController = new OrderController(dbContext, logger, serializer);
            var accountController = new AccountController(dbContext, logger, serializer);
           
            var productUi = new ProductUi(display, dbContext, productController);
            var orderUi = new OrderUi(dbContext, display, orderController, productUi);
            var accountUi = new AccountUi(display,accountController, validator);

            var menu = new Menu(productUi, orderUi, accountUi, display);

            serializer.DeSerializeProducts();
            serializer.DeSerializeOrders();
            serializer.DeSerializeUsers();

            display.PrintForDisplay("Здравствуйте! Вас приветствует магазин Store Phone!\n");
            while (true)
            {
                menu.GetMenu();         
            }
        }
    }
}