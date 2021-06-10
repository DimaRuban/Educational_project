using Newtonsoft.Json;
using StorePhone.Controllers;
using StorePhone.Data;
using StorePhone.Logging;
using StorePhone.Models;
using StorePhone.UI;
using StorePhone.Validation;
using System.Collections.Generic;
using System.IO;

namespace EducationalProject
{
    class Program
    {
        static void Main(string[] args)   
        {   
            var display = new Display();
            
            var dbContext = new DbContext();   
            
            var logger = new Logger();

            var validator = new Validator(dbContext, display);

            var productController = new ProductController(dbContext, logger);
            var orderController = new OrderController(dbContext, logger);
            var accountController = new AccountController(dbContext, logger);
           
            var productUi = new ProductUi(display, dbContext, productController);
            var orderUi = new OrderUi(dbContext, display, orderController, productUi);
            var accountUi = new AccountUi(display,accountController, validator);

            var menu = new Menu(productUi, orderUi, accountUi, display);

            dbContext.Init();

            display.PrintForDisplay("Здравствуйте! Вас приветствует магазин Store Phone!\n");
            while (true)
            {
                menu.GetMenu();         
            }
        }
    }
}