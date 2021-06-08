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

        public decimal CountPriceToUsd(decimal totalPrice)
        {
            var currency = _dbContext.Currencies.FirstOrDefault(currency => currency.CurrencyName == "USD");

            return totalPrice / currency.RateCurrencySale;
        }

        public decimal CountPriceToEur(decimal totalPrice)
        {
            var currency = _dbContext.Currencies.FirstOrDefault(currency => currency.CurrencyName == "EUR");

            return totalPrice / currency.RateCurrencySale;
        }

        public decimal CountPriceToBtc(decimal totalPriceUsd)
        {
            var currency = _dbContext.Currencies.FirstOrDefault(currency => currency.CurrencyName == "BTC");

            return totalPriceUsd / currency.RateCurrencySale;
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
            _logger.Log($"{DateTime.Now} - был создан новый заказ, с ID = {newOrderId}");
            _serializer.SerializeOrders();
        }
    }
}