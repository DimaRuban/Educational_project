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

        public OrderController(IDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
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
             var newOrderId = _dbContext.Orders.Max(x => x.Id) + 1;

            _dbContext.Orders.Add(new Order(newOrderId, DateTime.Now, userName, phoneNumber, address, quantity, totalPrice));
            _dbContext.Save();
            _logger.Log($"{DateTime.Now} - был создан новый заказ, с ID = {newOrderId}");
        }
    }
}