using StorePhone.Controllers;
using StorePhone.Data;
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
           
            var validator = new Validator(dbContext, display);

            var productController = new ProductController(dbContext);
            var orderController = new OrderController(dbContext);
            var accountController = new AccountController(dbContext);
           
            var productUi = new ProductUi(display, dbContext, productController);
            var orderUi = new OrderUi(dbContext, display, orderController, productUi, validator);
            var accountUi = new AccountUi(display,accountController, validator);

            var menu = new Menu(productUi, orderUi, accountUi, display);

            display.PrintForDisplay("Здравствуйте! Вас приветствует магазин Store Phone!\n");
            while (true)
            {
                menu.GetMenu();         
            }
        }
    }
}