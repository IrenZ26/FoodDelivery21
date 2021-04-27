using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    public class BuyerClient
    {
        public int GetProductId(ProductData productData)
        {
            foreach (var item in productData.Products)
            {
                Console.WriteLine(item.Name + " from " + item.CompanyName + " costs " + item.Price + "$." + "Available: " + item.AvailableValue + " items");
            }
            Console.WriteLine("Enter products`s id");
            string ans = Console.ReadLine();
            Validator validator = new Validator();
            int k = validator.IsValidInt(ans);
            return k;
        }
        public void ShowOrder(OrderData orderData, decimal totalPrice) 
        {
            Console.WriteLine("Your order: ");
            foreach (var item in orderData.Orders)
            {
                decimal discount = item.Discount * 100;
                Console.WriteLine(item.Product.Name + " " + item.ProductValue + " items, costs " + item.Product.Price + "$ for one item.\nDiscount = " + discount + "%. Total price = " + item.TotalPrice + "$");
                totalPrice += item.TotalPrice;
            }
            Console.WriteLine("Total price of the whole order with delivery = " + totalPrice + "$");
        }
        public decimal GetItemsCount()
        {
            Console.WriteLine("Enter how many items you want to buy");
            string ans = Console.ReadLine();
            Validator validator = new Validator();
            decimal val = validator.IsValidDecimal(ans);
            return val;
        }
        public string GetPromo()
        {
            Console.WriteLine("Enter your promocode. If you don`t have any promo code, just press 'Enter'");
            string promo = Console.ReadLine();
            return promo;
        }
        public bool Continue()
        {
            bool f = false;
            Console.WriteLine("If you want to continue shopping enter 'Y/y'.\nIf your order is complete, enter any other key.");
            string ans = Console.ReadLine();
            if (ans == "Y") { f = true; }
            else if (ans == "y") { f = true; }
            return f;
        }
        public int ShowDelivery(DeliveryData deliveryData)
        {
            foreach (var item in deliveryData.Deliveries)
            {
                Console.WriteLine(item.Method + " costs " + item.Price + "$");
            }
            Console.WriteLine("Enter delivery method`s id");
            string ans = Console.ReadLine();
            Validator validator = new Validator();
            int k = validator.IsValidInt(ans);
            return k; 
        }
        public void ShowQuantErrMassage(decimal value)
        {
            Console.WriteLine("Sorry we don`t have that many items in stock.\n Quantity of ordered products is: " + value);
        }
    }
}
