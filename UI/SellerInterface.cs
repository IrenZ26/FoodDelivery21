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
            var i = Console.ReadLine();
            var validator = new Validator();
            var id = validator.IntValidation(i);
            Console.WriteLine("Enter product name");
            var productName = Console.ReadLine();
            Console.WriteLine("Enter company price");
            var s = Console.ReadLine().Replace(".", ",");            
            var price = validator.DecimalValidation(s);
            Console.WriteLine("Enter quantity of products");
            var s1 = Console.ReadLine().Replace(".", ",");
            var availableValue = validator.DecimalValidation(s1);
            Console.WriteLine("Enter discount promo code");
            var promoCode = Console.ReadLine();
            Console.WriteLine("Enter product discount");
            var s2 = Console.ReadLine().Replace(".", ",");
            var productDiscount = validator.DecimalValidation(s2);
            Console.WriteLine("Enter personal discount");
            var s3 = Console.ReadLine().Replace(".", ",");
            var personalDiscount = validator.DecimalValidation(s3);
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
