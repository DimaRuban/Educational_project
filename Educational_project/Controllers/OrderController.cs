using StorePhone.Models;
using System;

namespace StorePhone.Controllers
{
    public static class OrderController
     { 
        public static int IdProductForBuy { get; set; }
        public static decimal  totalPriceOrder { get; set; }

        public static void ChoiceProduct()
        {
            try
            { 
                ProductController.PrintProduct();

                Console.Write("\nВведите Id товара, для покупки: ");

                IdProductForBuy = int.Parse(Console.ReadLine());

                foreach (var product in DbContext.products)
                {
                    if (product.Id == IdProductForBuy)
                    {
                        Console.Write($"\nВы действительно хотите оформить заказ Id = {product.Id}, Name = {product.Name} ?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
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
                Console.WriteLine(e.Message +"\n");
                Menu.GetMenu();
            }
        }

        public static void Buy()
        {
            try
            {
                int newOrderId = DbContext.orders.Count + 1;

                DateTime dateTimeCreatedOrder = DateTime.Now;

                Console.Write("\nВведите ваше имя: ");
                string userName = Console.ReadLine();

                int idProduct = IdProductForBuy;

                Console.Write("Введите адрес доставки: ");
                string adress = Console.ReadLine();

                Console.Write("Введите кол-во товара для покупки: ");
                int quantityProductForOrder = int.Parse(Console.ReadLine());

                foreach (var product in DbContext.products)
                    if (product.Id == IdProductForBuy)
                        totalPriceOrder = (decimal)quantityProductForOrder * product.Price;
                Console.WriteLine($"\nСумма вашего заказа: {totalPriceOrder}");

                Console.Write($"\n    Купить?\n Да - 1,\n Нет - 2.\nВыберете действие: ");
                int confirmButton = int.Parse(Console.ReadLine());
                switch (confirmButton)
                {
                    case 1:
                        DbContext.orders.Add(new Order(newOrderId, dateTimeCreatedOrder, new User { FirstName = userName }, new Product { Id = idProduct }, adress, quantityProductForOrder, totalPriceOrder));

                        Console.WriteLine("\nЗаказ оформлен, с вами свяжется администатор!\n");

                        foreach (var order in DbContext.orders)
                        {
                            Console.WriteLine($"Данные вашего заказа: \n Номер заказа: {order.Id}, Дата заказа: {order.CreatedAt}, Имя клиента: {order.User.FirstName}, Номер товара: {order.Product.Id}, Адресс доставки: {order.Address}, кол-во товара{quantityProductForOrder}, Сумма заказа: {totalPriceOrder}\n");
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
                Console.WriteLine(e.Message + "\n");
                Menu.GetMenu();
            }
        }
    }
}
