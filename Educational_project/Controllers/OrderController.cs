using StorePhone.Models;
using StorePhone.Сontracts;
using System;

namespace StorePhone.Controllers
{
    public class OrderController : IOrderController
    {  
        public int IdProductForBuy { get; set; }
        public decimal TotalPriceOrder { get; set; }

        private readonly IDbContext _dbContext;
        private readonly IProductController _productController;
        private readonly IOrderUi _orderUi;

        public OrderController(IDbContext dbContext, IProductController productController, IOrderUi orderUi)
        {
            _dbContext = dbContext;
            _productController = productController;
            _orderUi = orderUi;
        }

        public void ChoiceProduct()
        {   
            _productController.PrintProduct();
            _orderUi.ChoiceProductUi();
            IdProductForBuy = _orderUi.IdProductForBuy;
            switch (_orderUi.ConfirmButton)
            {
                case 1:
                    Buy();
                    break;
                default:
                    break;
            }
        }
        public void Buy()
        {
            _orderUi.BuyUi();
             int newOrderId = _dbContext.Orders.Count + 1;

             DateTime dateTimeCreatedOrder = DateTime.Now;

             foreach (var product in _dbContext.Products)
                 if (product.Id == IdProductForBuy)
                     TotalPriceOrder = (decimal)_orderUi.QuantityProductForOrder * product.Price;
                _orderUi.PrintTotalPrice(TotalPriceOrder);
 
             switch (_orderUi.ConfirmButton)
             {
                   case 1:
                        _dbContext.Orders.Add(new Order(newOrderId, dateTimeCreatedOrder, new User { FirstName = _orderUi.UserName }, new Product { Id = IdProductForBuy }, _orderUi.Adress, _orderUi.QuantityProductForOrder, TotalPriceOrder));
                    _orderUi.InformAboutSuccess();
                    break;
                default:
                    break;
            }
        }
    }
}
