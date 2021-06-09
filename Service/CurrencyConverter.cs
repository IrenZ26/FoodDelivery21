using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Service
{
    public class CurrencyConverter
    {
        public decimal currency = default;
        
        public async Task Convert(decimal price,string currencyName)
        {
            var data = new BankService();
            var currencies = await data.GetPlaceHolderApiDataAsync();
            dynamic json = JsonConvert.DeserializeObject(currencies);    
            decimal result = GetCurrency(json, currencyName);
            currency = ConvertCurrency(result, price);
        }

        public decimal GetCurrency(dynamic json, string currency)
        {
            decimal result = default;
            int currenciesNumber = 26;
            for (int i = 0; i < currenciesNumber; i++)
            {
                var money = json["exchangeRate"][i]["saleRateNB"];
                dynamic c = money.ToString();
                var currencyName = json["exchangeRate"][i]["currency"];
                if (currencyName == currency)
                {
                    decimal.TryParse(c, out result);                    
                }
            }
            return result;
        }

        public decimal ConvertCurrency(decimal currency, decimal price)
        {
            var totalPrice = price / currency;
            var result = Math.Round(totalPrice, 2);
            return result;
        }
    }
}
