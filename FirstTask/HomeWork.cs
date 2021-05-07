using System.Collections.Generic;

namespace FirstTask
{
    internal class HomeWork
    {
        private double InfantDiscount = 0.50;
        private double ChildDiscount = 0.25;
               
        private double SameStreetDiscount = 0.15;
        private decimal StreetDeliveryWayneStreet = 10;
        private decimal StreetDeliveryNorthHeatherStreet = 5.36m;
               
        private string StreetNameWayneStreet = "Wayne Street";
        private string StreetNameNorthHeatherStreet = "North Heather Street";
        private char AddressSeparator = ' ';
               
        private string UsdDesignator = "USD";
        private string EurDesignator = "EUR";
        private double UsdToEur = 0.84;

        private int Count = 0;

        private decimal GetFullPrice(
                                    IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    IEnumerable<decimal> prices,
                                    IEnumerable<string> currencies)
        {
            decimal fullPrice = default;

            foreach (var destination in destinations)
            {
                Count++;
                if (destination.Contains(StreetNameWayneStreet))
                {
                    
                }
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