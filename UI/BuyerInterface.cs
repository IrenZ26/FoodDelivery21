using FoodDelivery21.Contracts;
using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    public class ByuerInterface
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public ByuerInterface(IOrderService orderService, IProductService productService, IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
            _orderService = orderService;
            _productService = productService;
        }

        public ByuerInterface(){}

        public string ShowProducts() 
        {
            _productService.ShowProducts(); 
            Console.WriteLine("Enter products`s id");
            var result = Console.ReadLine();
            return result;
        }

        public string ExistMessage()
        {
            Console.WriteLine("You have existing orders. If you want to watch their status, enter 1. Or enter 2 to create a new one");
            var result = Console.ReadLine();
            return result;
        }

        public string ItemsMessage() 
        {
            Console.WriteLine("Enter how many items you want to buy");
            var result = Console.ReadLine();
            return result;
        }

        public string GetPromo()
        {
            Console.WriteLine("Enter your promocode. If you don`t have any promo code, just press 'Enter'");
            var promo = Console.ReadLine();
            return promo;
        }

        public bool Continue()
        {
            bool result = false;
            Console.WriteLine("If you want to continue shopping enter 'Y/y'.\nIf your order is complete, enter any other key.");
            var answer = Console.ReadLine();
            if (answer == "Y") { result = true; }
            else if (answer == "y") { result = true; }
            return result;
        }

        public string ShowDeliveries()
        {
            _deliveryService.ShowDeliveries();
            Console.WriteLine("Enter delivery method`s id");
            var result = Console.ReadLine();
            return result;
        }

        public void ShowQuantErrMessage(decimal value)
        {
            Console.WriteLine("Sorry we don`t have that many items in stock.\n Quantity of ordered products is: " + value);
        }
    }
}
