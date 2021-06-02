using StorePhone.Models;
using StorePhone.Сontracts;
using System;
using System.Linq;

namespace StorePhone.Controllers
{
    public class OrderController : IOrderController
    {  
        private readonly IDbContext _dbContext;

        public OrderController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string GetNameForProductId(int id)
        {          
            return _dbContext.Products.FirstOrDefault(x => x.Id == id)?.Name;
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
        }
    }
}