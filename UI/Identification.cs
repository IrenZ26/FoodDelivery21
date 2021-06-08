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
        private bool firstTime = true;
        public bool IsContinue()
        {
            bool result = false;
            if (!firstTime)
            {
                Console.WriteLine("Thank you for using our Delivery Service");
                Console.WriteLine("If you want to continue enter Y/y. If you want to exit enter any other key");
                var continueAnswer = Console.ReadLine();
                if ((continueAnswer == "Y") || (continueAnswer == "y")) 
                {
                    result = true; 
                }
            }
            else 
            {
                firstTime = false;
                result = true;
            }
            return result;
        }

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
            var initializator = new DataInitializator();
            var deliveryData = initializator.GetDeliveryData();
            var orderData = initializator.GetOrdersData();
            var productData = initializator.GetProductsData();
            var cache = new CacheMaker();
            cache.StartCaching(productData, orderData, deliveryData);
            bool IsCont = true;
            while (IsCont)
            {
                bool roleValid = false;
                IsCont = false;
                firstTime = false;
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
                    buyerUI.CreateOrder(cache.cacheDeliveryData, cache.cacheOrderData, cache.cacheProductData, orderData, productData, buyer);
                }
                else if (role == 2)
                {
                    roleValid = true;
                    var seller = new SellerUI();
                    seller.StartWorking(name, cache.cacheProductData, productData, orderData);
                }
                else
                {
                    Console.WriteLine("Your role isn`t valid. Try again");
                }
            }
            initializator.SaveData<DeliveryData>(deliveryData);
            initializator.SaveData<OrderData>(orderData);
            initializator.SaveData<ProductData>(productData);
            IsCont = IsContinue();            
        }
        }
    }
}
