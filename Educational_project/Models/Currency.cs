using Newtonsoft.Json;

namespace StorePhone.Models
{
    public class Currency
    {
        public Currency()
        {
        }

        public Currency(string currencyName, string baseCurrencyName, decimal rateCurrencyBuy, decimal rateCurrencySale)
        {
            CurrencyName = currencyName;
            BaseCurrencyName = baseCurrencyName;
            RateCurrencyBuy = rateCurrencyBuy;
            RateCurrencySale = rateCurrencySale;
        }

        [JsonProperty("ccy")]
        public string CurrencyName { get; set; }

        [JsonProperty("base_ccy")]
        public string BaseCurrencyName { get; set; }

        [JsonProperty("buy")]
        public decimal RateCurrencyBuy { get; set; }

        [JsonProperty("sale")]
        public decimal RateCurrencySale { get; set; }
    }
}