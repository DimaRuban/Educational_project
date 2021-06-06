using StorePhone.Logging;
using StorePhone.Models;
using StorePhone.Сontracts;
using System;
using System.Linq;

namespace StorePhone.Controllers
{
    public class OrderController : IOrderController
    {  
        private readonly IDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly ISerializer _serializer;

        public OrderController(IDbContext dbContext, ILogger logger,ISerializer serialazer)
        {
            _dbContext = dbContext;
            _logger = logger;
            _serializer = serialazer;
        }
        public decimal CountTotalPrice(int idProductForBuy, int quantity)
        {
            decimal totalPrice = 0;

            foreach (var product in _dbContext.Products)
                if (product.Id == idProductForBuy)
                    totalPrice = (decimal)quantity * product.Price;
            return totalPrice;
        }
        public void Buy(decimal totalPrice, int quantity, string userName, string phoneNumber, string address)
        {
             int newOrderId = _dbContext.Orders.Max(x => x.Id) + 1;

            _dbContext.Orders.Add(new Order(newOrderId, DateTime.Now, userName, phoneNumber, address, quantity, totalPrice));           
            _logger.Log($"{DateTime.Now} - был создан новый заказ, с ID = {newOrderId}");
            _serializer.SerializeOrders();
        }
    }
}