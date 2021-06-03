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
            var name = Console.ReadLine();
            bool addressValid = false;
            var validator = new Validator();
            while (!addressValid)
            {
                Console.WriteLine("Enter your address");
                var address = Console.ReadLine();
                addressValid = validator.AddressValidation(address);
                if (!addressValid) { Console.WriteLine("Your address isn`t valid. Try again"); }
            }
            bool telephoneValid = false;
            while (!telephoneValid)
            {
                Console.WriteLine("Enter your telephone number");
                var telephone = Console.ReadLine();
                telephoneValid = validator.TelephoneValidation(telephone);
                if (!telephoneValid) { Console.WriteLine("Your telephone number isn`t valid. Try again"); }
            }
            bool roleValid = false;
            while (!roleValid)
            {
                Console.WriteLine("Enter 1 if you are a buyer or 2 if you are a seller");
                var answer = Console.ReadLine();
                int role;
                int.TryParse(answer, out role);
                if (role == 1)
                {
                    roleValid = true;
                    var order = new OrderUI();
                    order.CreateOrder();
                }
                else if (role == 2)
                {
                    roleValid = true;
                    var seller = new SellerUI();
                    seller.StartWorking(name);
                }
                else
                {
                    Console.WriteLine("Your role isn`t valid. Try again");
                }
            }
        }
      

    }
}
