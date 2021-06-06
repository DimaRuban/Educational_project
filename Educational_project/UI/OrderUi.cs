using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class OrderUi : IOrderUi
    {
        private int IdProductForBuy { get; set; }

        private readonly IDisplay _display;
        private readonly IOrderController _orderController;
        private readonly IProductUi _productUi;
        private readonly IValidator _validator;

        public OrderUi( IDisplay display, IOrderController orderController, IProductUi productUi, IValidator validator)
        {
            _display = display;
            _orderController = orderController;
            _productUi = productUi;
            _validator = validator;
        }

        public void ChooseProductUi() 
        {
            try
            {
                _productUi.PrintProductUi();
                _display.Print("\nВведите Id товара, для покупки: ");
                IdProductForBuy = int.Parse(Console.ReadLine());   
                
                _display.Print($"\nВы действительно хотите оформить заказ Id = {IdProductForBuy}, Name = {_orderController.GetNameForProductId(IdProductForBuy)} ?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                int confirmButton = int.Parse(Console.ReadLine());
                                
                switch (confirmButton)
                {
                    case 1:
                        BuyProductUi();
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException e)
            {
                _display.Print(e.Message + "\n");
            }
        }

        private void BuyProductUi() 
        {
            try
            {
                _display.Print("\nВведите ваше имя: ");
                string userName = Console.ReadLine();

                _display.Print("Введите номер телефона: ");
                string phoneNumber = Console.ReadLine();
                if (!_validator.IsPhoneNumberValid(phoneNumber))
                {
                    _display.Print("\nВведите корректный номер телефона!");
                    BuyProductUi();
                }

                _display.Print("Введите адрес доставки: ");
                string address = Console.ReadLine();
                if (!_validator.IsHomeAddressValid(address))
                {
                    _display.Print("Вы ввели некорректный адрес!");
                    BuyProductUi();
                }

                _display.Print("Введите кол-во товара для покупки: ");
                int quantity = int.Parse(Console.ReadLine());

                _display.Print($"\n   Купить?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                int confirmButton = int.Parse(Console.ReadLine());
               
                if (confirmButton == 1) 
                {
                    decimal totalPrice = _orderController.CountTotalPrice(IdProductForBuy, quantity);

                    PrintTotalPriceUi(totalPrice);

                    _orderController.BuyProduct(totalPrice, quantity, userName, phoneNumber, address);

                    InformAboutSuccessUi(userName, phoneNumber, IdProductForBuy, address, quantity, totalPrice);
                } 
                else
                {
                    BuyProductUi();
                }
            }
            catch (FormatException e)
            {
                _display.Print(e.Message + "\n");
            }
        }

        private void PrintTotalPriceUi(decimal totalPrice)
        {
            _display.Print($"\nСумма вашего заказа: {totalPrice} грн");
        }

        private void InformAboutSuccessUi(string userName, string phoneNumber, int IdProductForBuy, string address, int quantity, decimal totalPrice)
        {
            _display.Print("\nЗаказ оформлен, с вами свяжется администатор!\n");

            _display.Print($"\nДанные вашего заказа: \n Дата заказа: {DateTime.Now},\n Имя клиента: {userName},\n Номер телефона: {phoneNumber},\n Номер товара: {IdProductForBuy},\n Адресс доставки: {address},\n кол-во товара: {quantity},\nСумма вашего заказа: {totalPrice}\n\n");        
        }
    }      
 }