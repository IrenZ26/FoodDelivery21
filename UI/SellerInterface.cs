using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    public class SellerInterface
    {
        public Product CreateProduct(string companyName)
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
            Console.WriteLine("If you want to update your products enter 1\nIf you want to add new products enter 2\nIf you want to delete your products enter 3");
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
    }
}
