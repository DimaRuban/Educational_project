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
           
            var validator = new Validator(dbContext);

            var productController = new ProductController(dbContext);
            var orderController = new OrderController(dbContext);
            var accountController = new AccountController(dbContext);
           
            var productUi = new ProductUi(display, dbContext, productController);
            var orderUi = new OrderUi(display, orderController, productUi);
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