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

        public OrderUi(IDbContext dbContext, IDisplay display, IOrderController orderController, IProductUi productUi)
        {
            _dbContext = dbContext;
            _display = display;
            _orderController = orderController;
            _productUi = productUi;
        }
        public void ChoiceProductUi() 
        {
            try
            {
                _productUi.PrintProductUi();
                _display.PrintForDisplay("\nВведите Id товара, для покупки: ");
                _orderController.IdProductForBuy = int.Parse(Console.ReadLine());
               
                foreach (var product in _dbContext.Products)
                {
                    if (product.Id == _orderController.IdProductForBuy)
                    {
                        _display.PrintForDisplay($"\nВы действительно хотите оформить заказ Id = {product.Id}, Name = {product.Name} ?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                        _orderController.ConfirmButton = int.Parse(Console.ReadLine());
                    }
                }
                switch (_orderController.ConfirmButton)
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
                _orderController.UserName = Console.ReadLine();

                _display.PrintForDisplay("Введите адрес доставки: ");
                _orderController.Adress = Console.ReadLine();

                _display.PrintForDisplay("Введите кол-во товара для покупки: ");
                _orderController.QuantityProductForOrder = int.Parse(Console.ReadLine());

                _display.PrintForDisplay($"\n   Купить?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                _orderController.ConfirmButton = int.Parse(Console.ReadLine());
               
                if (_orderController.ConfirmButton == 1) 
                {
                    _orderController.Buy();
                    PrintTotalPriceUi(_orderController.TotalPriceOrder);
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
                _display.PrintForDisplay($"\nДанные вашего заказа: \n Номер заказа: {order.Id},\n Дата заказа: {order.CreatedAt},\n Имя клиента: {order.User.FirstName},\n Номер товара: {order.Product.Id},\n Адресс доставки: {order.Address},\n кол-во товара: {_orderController.QuantityProductForOrder},\nСумма вашего заказа: {_orderController.TotalPriceOrder}\n\n");
            }
        }
    }      
 }