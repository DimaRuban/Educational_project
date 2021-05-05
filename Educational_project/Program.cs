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
            var accountUi = new AccountUi(display);
            var productUi = new ProductUi(display,dbContext);
            var orderUi = new OrderUi(dbContext, display);
            var validator = new Validator(dbContext, display);
            var productController = new ProductController(dbContext, productUi);
            var orderController = new OrderController(dbContext, productController,orderUi);
            var accountController = new AccountController(dbContext, validator, accountUi);
            var menu = new Menu(productController,orderController,accountController,display);

            display.PrintForDisplay("Здравствуйте! Вас приветствует магазин Store Phone!\n");
            while (true)
            {
                menu.GetMenu();         
            }
        }
    }
}
