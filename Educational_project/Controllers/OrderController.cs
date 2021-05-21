using StorePhone.Models;
using StorePhone.Сontracts;
using System;
using System.Linq;

namespace StorePhone.Controllers
{
    public class OrderController : IOrderController
    {  
        private readonly IDbContext _dbContext;
        private readonly Order _order;
        private readonly ILogger _logger;

        public OrderController(IDbContext dbContext, Order order, ILogger logger)
        {
            _dbContext = dbContext;
            _order = order;
            _logger = logger;
        }

        public void Buy()
        {
             int newOrderId = _dbContext.Orders.Max(x => x.Id) + 1;

            DateTime dateTimeCreatedOrder = DateTime.Now;

             foreach (var product in _dbContext.Products)
                 if (product.Id == _order.IdProductForBuy)
                    _order.TotalPrice = (decimal)_order.Quantity * product.Price;
 
             switch (_order.ConfirmButton)
             {
                   case 1:
                        _dbContext.Orders.Add(new Order(newOrderId, dateTimeCreatedOrder, _order.UserName, _order.Address, _order.Quantity, _order.TotalPrice));
                        _logger.Log($"{dateTimeCreatedOrder} - был создан новый заказ, с ID = {newOrderId}");
                    break;
                default:
                    break;
            }
        }
    }
}