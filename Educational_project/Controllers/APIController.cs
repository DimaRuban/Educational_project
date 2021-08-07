using Newtonsoft.Json;
using StorePhone.Models;
using StorePhone.Сontracts;
using System.Collections.Generic;
using System.Net.Http;

namespace StorePhone.Controllers
{
    public class ApiController
    {
        private readonly IDbContext _dbContext;

        public ApiController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void GetCurrencyAsync()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync(@"https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");
            var currencyes = JsonConvert.DeserializeObject<List<Currency>>(response);

            foreach (var currency in currencyes)
            {
                _dbContext.Currencies.Add(new Currency(currency.CurrencyName, currency.BaseCurrencyName, currency.RateCurrencyBuy, currency.RateCurrencySale));
            }
        }
    }
}