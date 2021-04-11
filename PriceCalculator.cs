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
            List<string> destinationsList = destinations.ToList();
            List<string> clientsList = clients.ToList();
            List<string> currenciesList = currencies.ToList();
            List<int> infantsIdsList = infantsIds.ToList();
            List<int> childrenIdsList = childrenIds.ToList();
            List<decimal> pricesList = prices.ToList();
            
            if (Validation(destinationsList.Count(), clientsList.Count(), pricesList.Count(), currenciesList.Count())) 
            {
                pricesList = PriceDiscount(destinationsList, clientsList, pricesList, infantsIdsList, childrenIdsList, currenciesList);
                foreach (decimal i in pricesList)
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
        private bool Validation(int destinationsCount, int clientsCount, int pricesCount, int currenciesCount) {
            if ((destinationsCount.Equals(clientsCount))&&(destinationsCount.Equals(pricesCount)) && (destinationsCount.Equals(currenciesCount)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private List<decimal> PriceDiscount(List<string> destinationsList, List<string> clientsList, List<decimal> pricesList, List<int> infantsIdsList, List<int> childrenIdsList, List<string> currenciesList)
        {
            decimal finalPrice;
            string s,s1;
            for(int i = 0; i < pricesList.Count; i++)
            {
                if (currenciesList[i]== "EUR") { pricesList[i] =  СurrencyConverter(pricesList[i]);}
                decimal discount = 0;
                decimal discountedPrice = 0;
                finalPrice = PriceDiscountAdress(pricesList[i], destinationsList[i]);
                s = GetStreet(destinationsList[i]);
                if (i > 0) 
                {
                    s1 = GetStreet(destinationsList[i-1]);
                    if (s == s1) 
                    {
                        discount += 0.15m;
                    }
                }
                if (infantsIdsList.Contains(i)) 
                {
                    discount += 0.5m;
                }
                if (childrenIdsList.Contains(i))
                {
                    discount += 0.25m;
                }
                discountedPrice = GetDiscount(finalPrice, discount);
                pricesList[i] = discountedPrice;
            }
            return pricesList;
        }
        private decimal GetDiscount(decimal price, decimal discount)
        {
            decimal result = Math.Round(price - (price * discount), 2);
            return result;
        }
        private string GetStreet(string adress)
        {
            string[] parts = adress.Split(',');
            int found = parts[0].IndexOf(" ");
            string res = parts[0].Substring(found + 1);
            return res;
        }
        private decimal PriceDiscountAdress(decimal price, string adress) 
        {
            if (adress.Contains("Wayne Street")){ price = price + 10; }
            if (adress.Contains("North Heather Street")) { price = price - 5.36m; }
            return price;
        }
        public decimal СurrencyConverter(decimal euroPrice)
        {
           decimal dollarPrice = euroPrice * 1.19m;
           decimal result = Math.Round(dollarPrice, 2);
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
