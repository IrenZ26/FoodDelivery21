using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Service
{
    public class BankService
    {
        public async Task<string> GetPlaceHolderApiDataAsync()
        {
            var path = GetPath();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            var response = await client.SendAsync(request).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync();
        }

        private string GetPath()
        {
            var path = "https://api.privatbank.ua/p24api/exchange_rates?json&date=";
            var yesterday = DateTime.Today.Date.AddDays(-1).ToString("d");
            var result = path + yesterday;
            return result;
        }
    }
}
