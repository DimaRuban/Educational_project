using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class OrderUi : IOrderUi
    {
        public int IdProductForBuy { get; set; }
        public  string UserName { get; set; }
        public string Adress { get; set; }
        public int QuantityProductForOrder { get; set; }
        public int ConfirmButton { get; set; }


        private readonly IDbContext _dbContext;
        private readonly IDisplay _display;

        public OrderUi(IDbContext dbContext, IDisplay display)
        {
            _dbContext = dbContext;
            _display = display;
        }
        public void ChoiceProductUi() {
            try
            {
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

                _display.PrintForDisplay("Введите адрес доставки: ");
                Adress = Console.ReadLine();

                _display.PrintForDisplay("Введите кол-во товара для покупки: ");
                QuantityProductForOrder = int.Parse(Console.ReadLine());

                _display.PrintForDisplay($"\n   Купить?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                ConfirmButton = int.Parse(Console.ReadLine());                                                                             
            }
            catch (FormatException e)
            {
                _display.PrintForDisplay(e.Message + "\n");
            }
        }
        public void PrintTotalPrice(decimal totalPrice)
        {
            _display.PrintForDisplay($"\nСумма вашего заказа: {totalPrice} грн");
        }
        public void InformAboutSuccess()
        {
            _display.PrintForDisplay("\nЗаказ оформлен, с вами свяжется администатор!\n");

            foreach (var order in _dbContext.Orders)
            {
                _display.PrintForDisplay($"\nДанные вашего заказа: \n Номер заказа: {order.Id},\n Дата заказа: {order.CreatedAt},\n Имя клиента: {order.User.FirstName},\n Номер товара: {order.Product.Id},\n Адресс доставки: {order.Address},\n кол-во товара: {QuantityProductForOrder},\n\n");
            }
        }
    }      
 }
