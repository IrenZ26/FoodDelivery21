using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    public class SellerInterface
    {
        public Product CreateProduct(string companyName,ProductData productData)
        {
            Console.WriteLine("Enter product id");
            var answer = Console.ReadLine();
            int id;
            int.TryParse(answer, out id);
            Console.WriteLine("Enter product name");
            var productName = Console.ReadLine();
            Console.WriteLine("Enter company price");
            answer = Console.ReadLine().Replace(".", ",");
            decimal price;
            decimal.TryParse(answer, out price);
            Console.WriteLine("Enter quantity of products");
            answer = Console.ReadLine().Replace(".", ",");
            decimal availableValue;
            decimal.TryParse(answer, out availableValue);
            Console.WriteLine("Enter discount promo code");
            var promoCode = Console.ReadLine();
            Console.WriteLine("Enter product discount");
            answer = Console.ReadLine().Replace(".", ",");
            decimal productDiscount;
            decimal.TryParse(answer, out productDiscount);
            Console.WriteLine("Enter personal discount");
            answer = Console.ReadLine().Replace(".", ",");
            decimal personalDiscount;
            decimal.TryParse(answer, out personalDiscount);
            var product = new Product(id,productName, companyName, price, availableValue, promoCode, productDiscount, personalDiscount);
            Console.WriteLine("The product was succsesfully create:");
            Console.WriteLine("id:"+product.Id+" Name: " + product.Name + " Company: " + product.CompanyName + " Price: " + product.Price + "$ Avalible: " + product.AvailableValue + "items Promo code: " + product.DiscountPromoCode + " Product discount: " + product.ProductDiscount + " Personal discount: " + product.PersonalDiscount);
            return product;
        }

        public string ExistMassage()
        {
            Console.WriteLine("If you want to update your products enter 1\n" +
                "If you want to add new products enter 2\n" +
                "If you want to delete your products enter 3\n" +
                "If you want to see your product`s orders enter 4");
            var result = Console.ReadLine();
            return result;
        }

        public string ProductValueMassage()
        {
            Console.WriteLine("Enter how many items do you want to add");
            var result = Console.ReadLine();
            return result;
        }

        public string ShowProducts(ProductData productData, string companyName)
        {
            Console.WriteLine("Chose product and enter it`s id:");
            foreach (var item in productData.Products)
            {
                if (item.CompanyName.Equals(companyName))
                {
                    Console.WriteLine(item.Id + " " + item.Name);
                }
            }
            var result = Console.ReadLine();
            return result;
        }
        public string ShowOrdersStatus(OrderData orderData, string companyName)
        {
            foreach (var item in orderData.Orders)
            {
                if (item.Product.CompanyName == companyName)
                {
                    Console.WriteLine(item.Id + " product: " + item.Product.Name);
                }
            }
            Console.WriteLine("Enter the order`s id which status you want to change");
            string result = Console.ReadLine();
            return result;
        }
        public string ShowStatusMessage()
        {
            Console.WriteLine("What is a new status of selected order?\n" +
               "Enter 1 if the status is Cancelled\n" +
               "Enter 2 if the status is Packed\n" +
               "Enter 3 if the status is Delivered\n" +
               "Enter any other number if you dont want to change the status");
            var result = Console.ReadLine();
            return result;
        }
    }
}
