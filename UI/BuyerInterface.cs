using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    public class BuyerInterface
    {
       public string ShowProducts(ProductData productData) 
        {
            foreach (var item in productData.Products)
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
        public void ShowOrder(OrderData orderData, decimal totalPrice,Buyer buyer,bool isCreate) 
        {
            if (!isCreate)
            {
                var delivery = new DeliveryUI();
                totalPrice += delivery.GetDeliveryPrice(orderData, buyer);
            }
            Console.WriteLine("Your order: ");
            foreach (var item in orderData.Orders)
            {
                if ((item.Buyer.Name == buyer.Name) && (item.Buyer.Address == buyer.Address) && (item.Buyer.Telephone == buyer.Telephone))
                {
                    var discount = item.Discount * 100;
                    Console.WriteLine(item.Product.Name + " " + item.ProductValue + " items, costs " + item.Product.Price + "$ for one item.\nDiscount = " + discount + "%. Total price = " + item.TotalPrice + "$" + " Order status - "+item.Status);
                    totalPrice += item.TotalPrice;
                }
            }
            Console.WriteLine("Total price of the whole order with delivery = " + totalPrice + "$");
        }
<<<<<<< HEAD
<<<<<<< HEAD:UI/BuyerInterface.cs

=======
>>>>>>> regexValidation:UI/BuyerClient.cs
=======

>>>>>>> jsonSerialization
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
<<<<<<< HEAD:UI/BuyerInterface.cs

=======
>>>>>>> regexValidation:UI/BuyerClient.cs
        public string ShowDeliveries(DeliveryData deliveryData)
        {
            foreach (var item in deliveryData.Deliveries)
            {
                Console.WriteLine(item.Method + " costs " + item.Price + "$");
            }
            Console.WriteLine("Enter delivery method`s id");
            var result = Console.ReadLine();
            return result;
        }

        public void ShowQuantErrMassage(decimal value)
        {
            Console.WriteLine("Sorry we don`t have that many items in stock.\n Quantity of ordered products is: " + value);
        }
    }
}
