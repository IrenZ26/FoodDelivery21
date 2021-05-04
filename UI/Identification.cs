using FoodDelivery21.Contracts;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    public class Identification : IUser

    {
        public void Start()
        {
            Console.WriteLine("Welcome to the food delivery service. Please, identify yourself");
            Console.WriteLine("Enter your personal or company name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter yor address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter 1 if you are a buyer or 2 if you are a seller");
            string role = Console.ReadLine();
            var validator = new Validator();
            int r = validator.IsValidInt(role);
            if (r == 1)
            {
                var buyer = new BuyerService();
                buyer.CreateOrder();
            }
            else if (r == 2)
            { 
                var seller = new SellerClient();
                seller.Start(name);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
      

    }
}
