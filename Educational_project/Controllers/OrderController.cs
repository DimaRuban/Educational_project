﻿using StorePhone.Models;
using StorePhone.Сontracts;
using System;

namespace StorePhone.Controllers
{
    public class OrderController : IOrderController
    {  
        public int IdProductForBuy { get; set; }
        public decimal TotalPriceOrder { get; set; }
        public string UserName { get; set; }
        public string Adress { get; set; }
        public int QuantityProductForOrder { get; set; }
        public int ConfirmButton { get; set; }

        private readonly IDbContext _dbContext;

        public OrderController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Buy()
        {
             int newOrderId = _dbContext.Orders.Count + 1;

             DateTime dateTimeCreatedOrder = DateTime.Now;

             foreach (var product in _dbContext.Products)
                 if (product.Id == IdProductForBuy)
                     TotalPriceOrder = (decimal)QuantityProductForOrder * product.Price;
 
             switch (ConfirmButton)
             {
                   case 1:
                        _dbContext.Orders.Add(new Order(newOrderId, dateTimeCreatedOrder, new User { FirstName = UserName }, new Product { Id = IdProductForBuy }, Adress, QuantityProductForOrder, TotalPriceOrder));
                    break;
                default:
                    break;
            }
        }
    }
}