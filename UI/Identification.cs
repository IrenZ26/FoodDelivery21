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
            var logger = new Logger();
            Console.WriteLine("Welcome to the food delivery service. Please, identify yourself");
            Console.WriteLine("Enter your personal or company name");
            var name = Console.ReadLine();
<<<<<<< HEAD
            Console.WriteLine("Enter your address");
            var address = Console.ReadLine();
            Console.WriteLine("Enter your telephone number");
            var telephone = Console.ReadLine();
            var validator = new Validator();
            bool roleValid = false;
            var initializator = new DataInitializator();
            var deliveryData = initializator.GetDeliveryData();
            var orderData = initializator.GetOrdersData();
            var productData = initializator.GetProductsData();
            while (!roleValid)
            {
                Console.WriteLine("Enter 1 if you are a buyer or 2 if you are a seller");
<<<<<<< HEAD
<<<<<<< HEAD
                var answer = Console.ReadLine();
                var role = validator.CheckInt(answer);
=======
            bool addressValid = false;
            var validator = new Validator();
            while (!addressValid)
            {
                Console.WriteLine("Enter your address");
                var address = Console.ReadLine();
                addressValid = validator.ValidateAddress(address);
                if (!addressValid) { Console.WriteLine("Your address isn`t valid. Try again"); }
            }
            bool telephoneValid = false;
            while (!telephoneValid)
            {
                Console.WriteLine("Enter your telephone number");
                var telephone = Console.ReadLine();
                telephoneValid = validator.ValidateTelephone(telephone);
                if (!telephoneValid) { Console.WriteLine("Your telephone number isn`t valid. Try again"); }
            }
            bool roleValid = false;
            while (!roleValid)
            {
                Console.WriteLine("Enter 1 if you are a buyer or 2 if you are a seller");
                var answer = Console.ReadLine();
                int role;
                int.TryParse(answer, out role);
>>>>>>> regexValidation
                if (role == 1)
                {
                    roleValid = true;
                    var order = new OrderUI();
                    order.CreateOrder();
=======
                var role = Console.ReadLine();
                var r = validator.IntValidation(role);
                var loggerMassage = "";
                if (r == 1)
=======
                var answer = Console.ReadLine();
                var role = validator.IntValidation(answer);
                if (role == 1)
>>>>>>> jsonSerialization
                {
                    var buyerUI = new BuyerUI();
                    var buyer = buyerUI.CreateBuyer(name, address, telephone);
                    roleValid = true;
<<<<<<< HEAD
                    logger.SaveIntoFile("New session was strarted in buyer mode");
                    var order = new OrderUI();
                    order.CreateOrder();
                   logger.SaveIntoFile("New order was successfully saved");
>>>>>>> logger
=======
                    buyerUI.CreateOrder(deliveryData, orderData, productData, buyer);
>>>>>>> jsonSerialization
                }
                else if (role == 2)
                {
                    roleValid = true;
                    var seller = new SellerUI();
<<<<<<< HEAD
                    logger.SaveIntoFile("New session was strarted in seller mode");
                    seller.StartWorking(name);
=======
                    seller.StartWorking(name, productData,orderData);
>>>>>>> jsonSerialization
                }
                else
                {
                    Console.WriteLine("Your role isn`t valid. Try again");
                }
                logger.SaveIntoFile("The session was successfully finished");
            }
            Console.WriteLine("Thank you for using our Delivery Service");
            initializator.SaveData<DeliveryData>(deliveryData);
            initializator.SaveData<OrderData>(orderData);
            initializator.SaveData<ProductData>(productData);
        }
    }
}
