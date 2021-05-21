using StorePhone.Controllers;
using StorePhone.Data;
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
           
            var validator = new Validator(dbContext, display);

            var product = new Product();
            var order = new Order();
            var user = new User();

            var productController = new ProductController(dbContext, product);
            var orderController = new OrderController(dbContext, order);
            var accountController = new AccountController(dbContext, user);
           
            var productUi = new ProductUi(display, dbContext, productController, product);
            var orderUi = new OrderUi(dbContext, display, orderController, productUi, validator, order);
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