using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class OrderUi : IOrderUi
    {
        public int IdProductForBuy { get; set; }
        private readonly IDisplay _display;
        private readonly IOrderController _orderController;
        private readonly IProductUi _productUi;

        public OrderUi( IDisplay display, IOrderController orderController, IProductUi productUi)
        {
            _display = display;
            _orderController = orderController;
            _productUi = productUi;
        }

        public void ChooseProductUi() 
        {
            try
            {
                _productUi.PrintProductUi();
                _display.Print("\nВведите Id товара, для покупки: ");
                int idProductForBuy = int.Parse(Console.ReadLine());               
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

        public void BuyProductUi() 
        {
            try
            {
                _display.Print("\nВведите ваше имя: ");
                string userName = Console.ReadLine();

                _display.Print("Введите номер телефона: ");
                string phoneNumber = Console.ReadLine();

                _display.Print("Введите адрес доставки: ");
                string address = Console.ReadLine();

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

        public void PrintTotalPriceUi(decimal totalPrice)
        {
            _display.Print($"\nСумма вашего заказа: {totalPrice} грн");
        }

        public void InformAboutSuccessUi(string userName, string phoneNumber, int IdProductForBuy, string address, int quantity, decimal totalPrice)
        {
            _display.Print("\nЗаказ оформлен, с вами свяжется администатор!\n");

            _display.Print($"\nДанные вашего заказа: \n Дата заказа: {DateTime.Now},\n Имя клиента: {userName},\n Номер телефона: {phoneNumber},\n Номер товара: {IdProductForBuy},\n Адресс доставки: {address},\n кол-во товара: {quantity},\nСумма вашего заказа: {totalPrice}\n\n");        
        }
    }      
 }