using System.Collections.Generic;
using System.Linq;

namespace Delivery_discount
{
    internal class HomeWork
    {
        private const double EurToUsd = 0.82;

        private const decimal StreetDeliveryPenalty = 10;
        private const decimal StreetDeliveryDiscount = 5.36m;

        private const string PenaltyStreetName = "Wayne Street";
        private const string DiscountStreetName = "North Heather Street";

        private const double InfantDiscount = 0.50;
        private const double ChildDiscount = 0.25;
        private const double SameStreetDiscount = 0.15;

        private IEnumerable<decimal> NormalizeCurrencies(IEnumerable<decimal> prices, IEnumerable<string> currencies)
        {
            var currenciesList = currencies.ToList();
            var priceList = prices.ToList();

            for (int i = 0; i < currenciesList.Count(); i++)
            {
                if (currenciesList[i].Contains("EUR"))
                {
                    priceList[i] = priceList[i] * (decimal)EurToUsd;
                }
            }
            return priceList;
        }

        private IEnumerable<decimal> ApplyStreetDiscount(IEnumerable<string> streetNames, IEnumerable<decimal> prices)
        {
            int index = 0;
            var priceList = prices.ToList();
            var nameStreets = streetNames.GetEnumerator();

            while (nameStreets.MoveNext())
            {
                if (nameStreets.Current == PenaltyStreetName)
                {
                    priceList[index] += (decimal)StreetDeliveryPenalty;
                }

                if (nameStreets.Current == DiscountStreetName)
                {
                    priceList[index] -= (decimal)StreetDeliveryDiscount;
                }
                index++;
            }
            return priceList;
        }

        private IEnumerable<decimal> ApplySameStreetDiscount(IEnumerable<string> streetNames, IEnumerable<decimal> prices)
        {
            var discountedPricesList = prices.ToList();
            var streetNamesList = streetNames.ToList();

            for (int i = 0; i < streetNames.Count() - 1; i++)
            {
                if (streetNamesList[i] == streetNamesList[i + 1])
                {
                    discountedPricesList[i + 1] -= discountedPricesList[i + 1] * (decimal)SameStreetDiscount;
                }
            }
            return discountedPricesList;
        }

        private IEnumerable<decimal> ApplyDiscountForKids(IEnumerable<int> infantsIds, IEnumerable<int> childrenIds, IEnumerable<decimal> prices)
        {
            var infantsIdsList = infantsIds.ToList();
            var childrenIdsList = childrenIds.ToList();
            var discountedPrices = prices.ToList();

            foreach (var id in infantsIdsList)
            {
                discountedPrices[id] -= discountedPrices[id] * (decimal)InfantDiscount;
            }
            foreach (var id in childrenIdsList)
            {
                discountedPrices[id] -= discountedPrices[id] * (decimal)ChildDiscount;
            }
            return discountedPrices;
        }
        private IEnumerable<string> GetStreetName(IEnumerable<string> destinations)
        {
            var streets = new List<string>();
            var destinationList = destinations.ToList();

            foreach (var destination in destinationList)
            {
                var streetSeparated = destination.Split(',')[0];
                var stringToDelete = streetSeparated.Substring(0, streetSeparated.IndexOf(" ") + 1);
                char[] charsToDelete = stringToDelete.ToCharArray();
                streetSeparated = streetSeparated.Trim(charsToDelete);
                streets.Add(streetSeparated);
            }
            return streets;
        }

        private decimal GetFullPrice(
                                    IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    IEnumerable<decimal> prices,
                                    IEnumerable<string> currencies)
        {
            decimal fullPrice = default;

            var deliveryPrice = NormalizeCurrencies(prices, currencies).ToList();
            var streetNames = GetStreetName(destinations).ToList();

            deliveryPrice = ApplyStreetDiscount(streetNames, deliveryPrice).ToList();
            deliveryPrice = ApplyDiscountForKids(infantsIds, childrenIds, deliveryPrice).ToList();
            deliveryPrice = ApplySameStreetDiscount(streetNames, deliveryPrice).ToList();

            for (int i = 0; i < deliveryPrice.Count(); i++)
            {
                fullPrice += deliveryPrice[i];
            }
            return fullPrice;
        }

        public decimal InvokePriceCalculatiion()
        {
            var destinations = new[]
            {
                "949 Fairfield Court, Madison Heights, MI 48071",
                "367 Wayne Street, Hendersonville, NC 28792",
                "910 North Heather Street, Cocoa, FL 32927",
                "911 North Heather Street, Cocoa, FL 32927",
                "706 Tarkiln Hill Ave, Middleburg, FL 32068",
            };

            var clients = new[]
            {
                "Autumn Baldwin",
                "Jorge Hoffman",
                "Amiah Simmons",
                "Sariah Bennett",
                "Xavier Bowers",
            };

            var infantsIds = new[] { 2 };
            var childrenIds = new[] { 3, 4 };

            var prices = new[] { 100, 25.23m, 58, 23.12m, 125 };
            var currencies = new[] { "USD", "USD", "EUR", "USD", "USD" };

            return GetFullPrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }
    }
}