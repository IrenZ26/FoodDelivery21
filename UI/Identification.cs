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
            var logger = new Logger();
            Console.WriteLine("Welcome to the food delivery service. Please, identify yourself");
            Console.WriteLine("Enter your personal or company name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter your address");
            var address = Console.ReadLine();
            Console.WriteLine("Enter your telephone number");
            var telephone = Console.ReadLine();
            var validator = new Validator();
            bool roleValid = false;
            while (!roleValid)
            {
                Console.WriteLine("Enter 1 if you are a buyer or 2 if you are a seller");
                var role = Console.ReadLine();
                var r = validator.IntValidation(role);
                var loggerMassage = "";
                if (r == 1)
                {
                    roleValid = true;
                    logger.SaveIntoFile("New session was strarted in buyer mode");
                    var order = new OrderUI();
                    order.CreateOrder();
                   logger.SaveIntoFile("New order was successfully saved");
                }
                else if (r == 2)
                {
                    roleValid = true;
                    var seller = new SellerUI();
                    logger.SaveIntoFile("New session was strarted in seller mode");
                    seller.StartWorking(name);
                }
                else
                {
                    Console.WriteLine("Your role isn`t valid. Try again");
                }
                logger.SaveIntoFile("The session was successfully finished");
            }
        }
      

    }
}
