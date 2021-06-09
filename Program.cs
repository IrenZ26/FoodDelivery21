using FoodDelivery21.Data;
using FoodDelivery21.Service;
using FoodDelivery21.UI;
using System;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var identification = new Identification();
           await identification.Start();
        }
    }
}
