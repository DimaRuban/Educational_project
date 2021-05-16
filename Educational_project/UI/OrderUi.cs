using StorePhone.Models;
using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class OrderUi : IOrderUi
    {
        private readonly IDbContext _dbContext;
        private readonly IDisplay _display;
        private readonly IOrderController _orderController;
        private readonly IProductUi _productUi;
        private readonly Order _order;

        public OrderUi(IDbContext dbContext, IDisplay display, IOrderController orderController, IProductUi productUi, Order order)
        {
            _dbContext = dbContext;
            _display = display;
            _orderController = orderController;
            _productUi = productUi;
            _order = order;
        }
        public void ChoiceProductUi() 
        {
            try
            {
                _productUi.PrintProductUi();
                _display.PrintForDisplay("\nВведите Id товара, для покупки: ");
                _order.IdProductForBuy = int.Parse(Console.ReadLine());
               
                foreach (var product in _dbContext.Products)
                {
                    if (product.Id == _order.IdProductForBuy)
                    {
                        _display.PrintForDisplay($"\nВы действительно хотите оформить заказ Id = {product.Id}, Name = {product.Name} ?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                        _order.ConfirmButton = int.Parse(Console.ReadLine());
                    }
                }
                switch (_order.ConfirmButton)
                {
                    case 1:
                        BuyUi();
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException e)
            {
                _display.PrintForDisplay(e.Message + "\n");
            }
        }
        public void BuyUi() 
        {
            try
            {
                _display.PrintForDisplay("\nВведите ваше имя: ");
                _order.UserName = Console.ReadLine();

                _display.PrintForDisplay("Введите адрес доставки: ");
                _order.Address = Console.ReadLine();

                _display.PrintForDisplay("Введите кол-во товара для покупки: ");
                _order.Quantity = int.Parse(Console.ReadLine());

                _display.PrintForDisplay($"\n   Купить?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                _order.ConfirmButton = int.Parse(Console.ReadLine());
               
                if (_order.ConfirmButton == 1) 
                {
                    _orderController.Buy();
                    PrintTotalPriceUi(_order.TotalPrice);
                    InformAboutSuccessUi();
                }
            }
            catch (FormatException e)
            {
                _display.PrintForDisplay(e.Message + "\n");
            }
        }
        public void PrintTotalPriceUi(decimal totalPrice)
        {
            _display.PrintForDisplay($"\nСумма вашего заказа: {totalPrice} грн");
        }
        public void InformAboutSuccessUi()
        {
            _display.PrintForDisplay("\nЗаказ оформлен, с вами свяжется администатор!\n");

            foreach (var order in _dbContext.Orders)
            {
                _display.PrintForDisplay($"\nДанные вашего заказа: \n Номер заказа: {order.Id},\n Дата заказа: {order.CreatedAt},\n Имя клиента: {_order.UserName},\n Номер товара: {_order.IdProductForBuy},\n Адресс доставки: {order.Address},\n кол-во товара: {_order.Quantity},\nСумма вашего заказа: {_order.TotalPrice}\n\n");
            }
        }
    }      
 }