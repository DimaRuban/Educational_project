using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class Menu : IMenu
    {
        private readonly IProductUi _productUi;
        private readonly IOrderUi _orderUi;
        private readonly IAccountUi _accountUi;
        private readonly IDisplay _display;

        public Menu(IProductUi productUi, IOrderUi orderUi, IAccountUi accountUi, IDisplay display)
        {
            _productUi = productUi;
            _orderUi = orderUi;
            _accountUi = accountUi;
            _display = display;
        }
        public void GetMenu()
        {
            try
            {
                _display.Print("\n\n*********МЕНЮ*********\n\nПросмотреть товар - 1,\nДобавить товар - 2,\nКупить товар - 3,\nЗарегистрироваться - 4,\nЗакрыть меню - 0\n\nВыберете дейсвие из списка: ");
                int operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        _productUi.PrintProductUi();
                        break;
                    case 2:
                        _productUi.AddNewProductUi();
                        break;
                    case 3:
                        _orderUi.ChoiceProductUi();
                        break;
                    case 4:
                        _accountUi.RegistrationUi();
                        break;
                    case 0:
                        OutMenu();
                        break;
                    default:
                        _display.Print("\nВыбирете операцию из списка!");
                        break;
                }
            }
            catch (FormatException e)
            {
                _display.Print(e.Message + "\n");
                GetMenu();
            }
        }
        void OutMenu ()
        {
            Environment.Exit(0);
        }
    }
}