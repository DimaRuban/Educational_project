using StorePhone.Models;
using StorePhone.Data;
using StorePhone.UI;
using StorePhone.Сontracts;
using System;


namespace StorePhone.Controllers
{
    public class OrderController
     {  
        private readonly ILogger _logger;
        private readonly IDbContext _dbContext;
        private readonly ProductController _productController;
        
        int IdProductForBuy { get; set; }
        decimal  totalPriceOrder { get; set; }
        public OrderController(IDbContext dbContext, ILogger logger, ProductController productController)
        {
            _dbContext = dbContext;
            _logger = logger;
            _productController = productController;
        }

        public void ChoiceProduct()
        {   
            try
            {
                _productController.PrintProduct();
                _logger.PrintForDisplay("\nВведите Id товара, для покупки: ");

                IdProductForBuy = int.Parse(Console.ReadLine());

                foreach (var product in _dbContext.products)
                {
                    if (product.Id == IdProductForBuy)
                    {
                        _logger.PrintForDisplay($"\nВы действительно хотите оформить заказ Id = {product.Id}, Name = {product.Name} ?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                        int confirmButton = int.Parse(Console.ReadLine());
                        switch (confirmButton)
                        {
                            case 1:
                                Buy();
                                break;
                            case 2:
                                Menu.GetMenu();
                                break;
                            default:
                                Menu.GetMenu();
                                break;
                        }
                    }
                }
            }
            catch (FormatException e)
            {
                _logger.PrintForDisplay(e.Message +"\n");
                Menu.GetMenu();
            }
        }

        public void Buy()
        {
            try
            {
                int newOrderId = _dbContext.orders.Count + 1;

                DateTime dateTimeCreatedOrder = DateTime.Now;

                _logger.PrintForDisplay("\nВведите ваше имя: ");
                string userName = Console.ReadLine();

                int idProduct = IdProductForBuy;

                _logger.PrintForDisplay("Введите адрес доставки: ");
                string adress = Console.ReadLine();

                _logger.PrintForDisplay("Введите кол-во товара для покупки: ");
                int quantityProductForOrder = int.Parse(Console.ReadLine());

                foreach (var product in _dbContext.products)
                    if (product.Id == IdProductForBuy)
                        totalPriceOrder = (decimal)quantityProductForOrder * product.Price;
                _logger.PrintForDisplay($"\nСумма вашего заказа: {totalPriceOrder}");

                _logger.PrintForDisplay($"\n    Купить?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                int confirmButton = int.Parse(Console.ReadLine());
                switch (confirmButton)
                {
                    case 1:
                        _dbContext.orders.Add(new Order(newOrderId, dateTimeCreatedOrder, new User { FirstName = userName }, new Product { Id = idProduct }, adress, quantityProductForOrder, totalPriceOrder));

                        _logger.PrintForDisplay("\nЗаказ оформлен, с вами свяжется администатор!\n");

                        foreach (var order in _dbContext.orders)
                        {
                            _logger.PrintForDisplay($"\nДанные вашего заказа: \n Номер заказа: {order.Id},\n Дата заказа: {order.CreatedAt},\n Имя клиента: {order.User.FirstName},\n Номер товара: {order.Product.Id},\n Адресс доставки: {order.Address},\n кол-во товара: {quantityProductForOrder},\n Сумма заказа: {totalPriceOrder}\n");
                        }
                        break;
                    case 2:
                        Menu.GetMenu();
                        break;
                    default:
                        Menu.GetMenu();
                        break;
                }
            }
            catch (FormatException e)
            {
                _logger.PrintForDisplay(e.Message + "\n");
                Menu.GetMenu();
            }
        }
    }
}
