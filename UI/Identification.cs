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
                var answer = Console.ReadLine();
                var role = validator.IntValidation(answer);
                if (role == 1)
                {
                    var buyerUI = new BuyerUI();
                    var buyer = buyerUI.CreateBuyer(name, address, telephone);
                    roleValid = true;
                    buyerUI.CreateOrder(deliveryData, orderData, productData, buyer);
                }
                else if (role == 2)
                {
                    roleValid = true;
                    var seller = new SellerUI();
                    seller.StartWorking(name, productData,orderData);
                }
                else
                {
                    Console.WriteLine("Your role isn`t valid. Try again");
                }
            }
            Console.WriteLine("Thank you for using our Delivery Service");
            initializator.SaveData<DeliveryData>(deliveryData);
            initializator.SaveData<OrderData>(orderData);
            initializator.SaveData<ProductData>(productData);
        }
      

    }
}
