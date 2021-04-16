using System;

namespace FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            PriceCalculator priceCalculator = new PriceCalculator();
            var result = priceCalculator.InvokePriceCalculatiion();
            Console.WriteLine("Full price of the delivery: "+result+" USD");
            Console.ReadLine();
        }
    }
}
