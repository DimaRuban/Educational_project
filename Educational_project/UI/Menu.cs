using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class Menu : IMenu
    {
        private readonly IProductController _productController;
        private readonly IOrderController _orderController;
        private readonly IAccountController _accountController;
        private readonly IDisplay _display;

        public Menu(IProductController productController, IOrderController orderController, IAccountController accountController, IDisplay display)
        {
            _productController = productController;
            _orderController = orderController;
            _accountController = accountController;
            _display = display;
        }
        public void GetMenu()
        {
            try
            {
                _display.PrintForDisplay("\n\n*********МЕНЮ*********\n\nПросмотреть товар - 1,\nДобавить товар - 2,\nКупить товар - 3,\nЗарегистрироваться - 4,\nЗакрыть меню - 0\n\nВыберете дейсвие из списка: ");
                int operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        _productController.PrintProduct();
                        break;
                    case 2:
                        _productController.AddNewProduct();
                        break;
                    case 3:
                        _orderController.ChoiceProduct();
                        break;
                    case 4:
                        _accountController.Registration();
                        break;
                    case 0:
                        OutMenu();
                        break;

                    default:
                        _display.PrintForDisplay("\nВыбирете операцию из списка!");
                        break;
                }
            }
            catch (FormatException e)
            {
                _display.PrintForDisplay(e.Message + "\n");
                GetMenu();
            }
        }
        void OutMenu ()
        {
            Environment.Exit(0);
        }
    }
}
