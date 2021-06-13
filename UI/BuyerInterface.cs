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
        private readonly IDeliveryData _deliveryData;
        private readonly IOrderData _orderData;
        private readonly IProductData _productData;
        public ByuerInterface(IDeliveryData deliveryData) 
        {
            _deliveryData = deliveryData;         
        }
        public ByuerInterface(IOrderData orderData) 
        {
            _orderData = orderData;
        }
        public ByuerInterface(IProductData productData)
        {
            _productData = productData;
        }
        public ByuerInterface(){}

        public string ShowProducts() 
        {
            foreach (var item in _productData.Products)
            {
                Console.WriteLine(item.Name + " from " + item.CompanyName + " costs " + item.Price + "$." + "Available: " + item.AvailableValue + " items");
            }
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

        public void ShowOrder(decimal totalPrice) 
        {
            Console.WriteLine("Your order: ");
            foreach (var item in _orderData.Orders)
            {
                    var discount = item.Discount * 100;
                    Console.WriteLine(item.Product.Name + " " + item.ProductValue + " items, costs " + item.Product.Price + "$ for one item.\nDiscount = " + discount + "%. Total price = " + item.TotalPrice + "$");
                    totalPrice += item.TotalPrice;
            }
            Console.WriteLine("Total price of the whole order with delivery = " + totalPrice + "$");
        }

        public string ItemsMassage() 
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
            foreach (var item in _deliveryData.Deliveries)
            {
                Console.WriteLine(item.Method + " costs " + item.Price + "$");
            }
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
