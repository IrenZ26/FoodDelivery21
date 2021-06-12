﻿using FoodDelivery21.Contracts;
using FoodDelivery21.Data;
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
            Console.WriteLine("Enter your address");
            var address = Console.ReadLine();
            Console.WriteLine("Enter your telephone number");
            var telephone = Console.ReadLine();
            var validator = new Validator();
            var roleValid = false;
            var deliveryData = new DeliveryData();
            deliveryData.DeliveryListInit();
            var orderData = new OrderData();
            var productData = new ProductData();
            productData.ProductsInit();
            var logger = new Logger();
            while (!roleValid)
            {
                Console.WriteLine("Enter 1 if you are a buyer or 2 if you are a seller");
                var answer = Console.ReadLine();
                var role = validator.CheckInt(answer);
                if (role == 1)
                {
                    roleValid = true;
                    logger.SaveIntoFile("New session was strarted in buyer mode");
                    var order = new OrderUI();
                    order.CreateOrder(deliveryData,orderData,productData,logger);
                    logger.SaveIntoFile("New order was successfully saved");
                }
                else if (role == 2)
                {
                    roleValid = true;
                    var seller = new SellerUI();
                    logger.SaveIntoFile("New session was strarted in seller mode");
                    seller.StartWorking(name,productData,logger);
                }
                else
                {
                    Console.WriteLine("Your role isn`t valid. Try again");
                }
            }
            Console.WriteLine("Thank you for using our Delivery Service");
            logger.SaveIntoFile("The session was successfully finished");
        }
    }
}
