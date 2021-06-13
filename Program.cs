using FoodDelivery21.Data;
using FoodDelivery21.Service;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodDelivery21
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var identification = new Identification();
            identification.Start();
        }

    }
}
