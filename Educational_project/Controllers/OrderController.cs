using StorePhone.Models;
using StorePhone.Сontracts;
using System;

namespace StorePhone.Controllers
{
    public class OrderController : IOrderController
    {  
        private readonly IDbContext _dbContext;
        private readonly Order _order;

        public OrderController(IDbContext dbContext, Order order)
        {
            _dbContext = dbContext;
            _order = order;
        }

        public void Buy()
        {
             int newOrderId = _dbContext.Orders.Count + 1;

             DateTime dateTimeCreatedOrder = DateTime.Now;

             foreach (var product in _dbContext.Products)
                 if (product.Id == _order.IdProductForBuy)
                    _order.TotalPrice = (decimal)_order.Quantity * product.Price;
 
             switch (_order.ConfirmButton)
             {
                   case 1:
                        _dbContext.Orders.Add(new Order(newOrderId, dateTimeCreatedOrder, _order.UserName, _order.Address, _order.Quantity, _order.TotalPrice));
                    break;
                default:
                    break;
            }
        }
    }
}