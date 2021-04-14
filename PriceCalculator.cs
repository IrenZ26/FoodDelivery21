using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery
{
    class PriceCalculator
    {
        private decimal GetFullPrice(
                                   IEnumerable<string> destinations,
                                   IEnumerable<string> clients,
                                   IEnumerable<int> infantsIds,
                                   IEnumerable<int> childrenIds,
                                   IEnumerable<decimal> prices,
                                   IEnumerable<string> currencies)
        {

            decimal fullPrice = default;
            
            if (Validator(destinations.Count(), clients.Count(), prices.Count(), currencies.Count())) 
            {
                prices = PriceDiscounter(destinations, prices, infantsIds, childrenIds, currencies);
                foreach (decimal i in prices)
                {
                    fullPrice += i;
                }
            }
            else
            {
                Console.WriteLine("Error: Data isn`t valid.");
            }
            return fullPrice;
        }
        private bool Validator(int destinationsCount, int clientsCount, int pricesCount, int currenciesCount) {
            if ((destinationsCount.Equals(clientsCount))&&(destinationsCount.Equals(pricesCount)) && (destinationsCount.Equals(currenciesCount)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private IEnumerable<decimal> PriceDiscounter(IEnumerable<string> destinations, IEnumerable<decimal> prices, IEnumerable<int> infantsIds, IEnumerable<int> childrenIds, IEnumerable<string> currencies)
        {
            decimal finalPrice;
            string s,s1;
            List<decimal> pricesList = prices.ToList();
            for (int i = 0; i < pricesList.Count; i++)
            {
                if (currencies.ElementAt(i)== "EUR") { pricesList[i] =  СurrencyConverter(pricesList[i]);}
                decimal discount = 0;
                decimal discountedPrice = 0;
                finalPrice = PriceDiscountAddress(pricesList[i], destinations.ElementAt(i));
                s = GetStreet(destinations.ElementAt(i));
                if (i > 0) 
                {
                    s1 = GetStreet(destinations.ElementAt(i-1));
                    if (s == s1) 
                    {
                        discount += 0.15m;
                    }
                }
                if (infantsIds.Contains(i)) 
                {
                    discount += 0.5m;
                }
                if (childrenIds.Contains(i))
                {
                    discount += 0.25m;
                }
                discountedPrice = GetDiscount(finalPrice, discount);
                pricesList[i] = discountedPrice;
            }
            prices = pricesList;
            return prices;
        }
        private decimal GetDiscount(decimal price, decimal discount)
        {
            decimal result = Math.Round(price - (price * discount), 2);
            return result;
        }
        private string GetStreet(string address)
        {
            var parts = address.Split(',');
            var found = parts[0].IndexOf(" ");
            var res = parts[0].Substring(found + 1);
            return res;
        }
        private decimal PriceDiscountAddress(decimal price, string address) 
        {
            if (address.Contains("Wayne Street")){ price = price + 10; }
            if (address.Contains("North Heather Street")) { price = price - 5.36m; }
            return price;
        }
        public decimal СurrencyConverter(decimal euroPrice)
        {
           var dollarPrice = euroPrice * 1.19m;
           var result = Math.Round(dollarPrice, 2);
           return result;
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
