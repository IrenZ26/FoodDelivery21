using FoodDelivery21.Data;
using FoodDelivery21.Service;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodDelivery21
{
    class Program
    {
        static void Main(string[] args)
        {
            //var deliveryData = new DeliveryData();
            //deliveryData.DeliveryListInit();

            ////var temp = new List<string> { "Q", "W", "E", "R", "T", "Y" };
            ////var s = temp.ElementAt(2);
            ////var d = temp[1];
            ////Console.WriteLine(s + " " + d);

            //var del = deliveryData.Deliveries.ElementAt(1);
            //Console.WriteLine(del.Method);
            var identification = new Identification();
            identification.Start();
        }
    }
}
