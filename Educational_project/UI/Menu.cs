using StorePhone.Controllers;
using StorePhone.Data;
using StorePhone.Validation;
using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public static class Menu
    {
        public static  void GetMenu()
        {
            var dbContext = new DbContext();
            var logger = new Logger();
            var validator = new Validator();
            var productController = new ProductController(dbContext, logger);
            var orderController = new OrderController(dbContext, logger, productController);
            var accountController = new AccountController(dbContext, logger, validator);

            try
            {
                logger.PrintForDisplay("\n\n*********МЕНЮ*********\n\nПросмотреть товар - 1,\nДобавить товар - 2,\nКупить товар - 3,\nЗарегистрироваться - 0\n\nВыберете дейсвие из списка: ");
                int operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        productController.PrintProduct();
                        break;
                    case 2:
                        productController.AddNewProduct();
                        break;
                    case 3:
                        orderController.ChoiceProduct();
                        break;
                    case 0:
                        accountController.Registration();
                        break;

                    default:
                        logger.PrintForDisplay("\nВыбирете операцию из списка!");
                        break;
                }
            }
            catch (FormatException e)
            {
                logger.PrintForDisplay(e.Message + "\n");
                GetMenu();
            }
        }
    }
}
