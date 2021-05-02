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
            bool addressValid = false;
            Validator validator = new Validator();
            while (!addressValid)
            {
                Console.WriteLine("Enter yor address");
                string address = Console.ReadLine();
                addressValid = validator.AddressValidation(address);
                if (!addressValid) { Console.WriteLine("Your address isn`t valid. Try again"); }
            }
            bool telephoneValid = false;
            while (!telephoneValid)
            {
                Console.WriteLine("Enter yor telephone number");
                string telephone = Console.ReadLine();
                telephoneValid = validator.TelephoneValidation(telephone);
                if (!telephoneValid) { Console.WriteLine("Your telephone number isn`t valid. Try again"); }
            }
            Console.WriteLine("Enter 1 if you are a buyer or 2 if you are a seller");
            string role = Console.ReadLine();         
            int r = validator.IsValidInt(role);
            if (r == 1)
            {
                BuyerService buyer = new BuyerService();
                buyer.CreateOrder();
            }
            else if (r == 2)
            { 
                SellerClient seller = new SellerClient();
                seller.Start(name);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
      

    }
}
