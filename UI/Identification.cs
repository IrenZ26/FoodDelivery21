using FoodDelivery21.Contracts;
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
            var validator = new Validator();
            var addressValid = false;
            while (!addressValid)
            {
                Console.WriteLine("Enter yor address");
                var address = Console.ReadLine();
                addressValid = validator.AddressValidation(address);
                if (!addressValid)
                {
                    Console.WriteLine("Your address isn`t valid. Try again");
                }
            }
            var telephoneValid = false;
            while (!telephoneValid)
            {
                Console.WriteLine("Enter yor telephone number");
                var telephone = Console.ReadLine();
                telephoneValid = validator.TelephoneValidation(telephone);
                if (!telephoneValid) 
                {
                    Console.WriteLine("Your telephone number isn`t valid. Try again");
                }
            }
            var roleValid = false;
            var deliveryData = new DeliveryData();
            deliveryData.DeliveryListInit();
            var orderData = new OrderData();
            var productData = new ProductData();
            productData.ProductsInit();
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
                    order.CreateOrder(deliveryData,orderData,productData);
                }
                else if (role == 2)
                {
                    roleValid = true;
                    var seller = new SellerUI();
                    seller.StartWorking(name,productData);
                }
                else
                {
                    Console.WriteLine("Your role isn`t valid. Try again");
                }
            }
            Console.WriteLine("Thank you for using our Delivery Service");
        }
    }
}
