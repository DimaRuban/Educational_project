using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class OrderUi : IOrderUi
    {
        public int ConfirmButton { get; set; }
        public int IdProductForBuy { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }

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
                IdProductForBuy = int.Parse(Console.ReadLine());
               
                foreach (var product in _dbContext.Products)
                {
                    if (product.Id == IdProductForBuy)
                    {
                        _display.PrintForDisplay($"\nВы действительно хотите оформить заказ Id = {product.Id}, Name = {product.Name} ?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                        ConfirmButton = int.Parse(Console.ReadLine());
                    }
                }
                switch (ConfirmButton)
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
                UserName = Console.ReadLine();

                _display.PrintForDisplay("Введите номер телефона: ");
                PhoneNumber = Console.ReadLine();

                _display.PrintForDisplay("Введите адрес доставки: ");
                Address = Console.ReadLine();

                _display.PrintForDisplay("Введите кол-во товара для покупки: ");
                Quantity = int.Parse(Console.ReadLine());

                _display.PrintForDisplay($"\n   Купить?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                ConfirmButton = int.Parse(Console.ReadLine());
               
                if (ConfirmButton == 1) 
                {
                    TotalPrice = _orderController.CountTotalPrice(IdProductForBuy, Quantity);

                    PrintTotalPriceUi(TotalPrice);

                    _orderController.Buy(TotalPrice, Quantity, UserName, PhoneNumber, Address);
                    InformAboutSuccessUi();
                }
                else
                {
                    BuyUi();
                }
            }
            catch (FormatException e)
            {
                _display.PrintForDisplay(e.Message + "\n");
            }
        }

        public void PrintTotalPriceUi(decimal totalPrice)
        {
            _display.PrintForDisplay($"\nСумма вашего заказа: {TotalPrice} грн");
        }
        public void InformAboutSuccessUi()
        {
            _display.PrintForDisplay("\nЗаказ оформлен, с вами свяжется администатор!\n");

            _display.PrintForDisplay($"\nДанные вашего заказа: \n Дата заказа: {DateTime.Now},\n Имя клиента: {UserName},\n Номер телефона: {PhoneNumber},\n Номер товара: {IdProductForBuy},\n Адресс доставки: {Address},\n кол-во товара: {Quantity},\nСумма вашего заказа: {TotalPrice}\n\n");

        }
    }      
 }