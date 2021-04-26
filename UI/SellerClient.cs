using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    class SellerClient
    {
        public Product CreateProduct(string companyName)
        {
            Console.WriteLine("Enter product id");
            string i = Console.ReadLine();
            Validator validator = new Validator();
            int id = validator.IsValidInt(i);
            Console.WriteLine("Enter product name");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter company price");
            string s = Console.ReadLine().Replace(".", ",");            
            decimal price = validator.IsValidDecimal(s);
            Console.WriteLine("Enter quantity of products");
            string s1 = Console.ReadLine().Replace(".", ",");
            decimal availableValue = validator.IsValidDecimal(s1);
            Console.WriteLine("Enter discount promo code");
            string promoCode = Console.ReadLine();
            Console.WriteLine("Enter product discount");
            string s2 = Console.ReadLine().Replace(".", ",");
            decimal productDiscount = validator.IsValidDecimal(s2);
            Console.WriteLine("Enter personal discount");
            string s3 = Console.ReadLine().Replace(".", ",");
            decimal personalDiscount = validator.IsValidDecimal(s3);
            Product product = new Product(id,productName, companyName, price, availableValue, promoCode, productDiscount, personalDiscount);
            Console.WriteLine("The product was succsesfully create:");
            Console.WriteLine("id:"+product.Id+"Name: " + product.Name + " Company: " + product.CompanyName + " Price: " + product.Price + "$ Avalible: " + product.AvailableValue + "items Promo code: " + product.DiscountPromoCode + " Product discount: " + product.ProductDiscount + " Personal discount: " + product.PersonalDiscount);

            return product;
        }
        public void Start(string companyName)
        {
            ProductData productData = new ProductData();
            productData.ProductsInit();
            SellerClient sellerClient = new SellerClient();
            bool isExist=false;
            foreach (var item in productData.Products)
            {
                if (item.CompanyName.Equals(companyName)) 
                {
                    isExist = true;                   
                }
            }
            if (isExist) 
            {
                Console.WriteLine("If you want to update your products enter 1\nIf you want to add new products enter 2\nIf you want to delete your products enter 3");
                string ans = Console.ReadLine();
                Validator validator = new Validator();
                int a = validator.IsValidInt(ans);
                if (a == 1)
                {
                    int prId = GetProduct(productData, companyName);
                    Console.WriteLine("Enter how many items do you want to add");
                    ans = Console.ReadLine();
                    decimal value = validator.IsValidDecimal(ans);
                    sellerClient.UpdateProduct(productData,prId,value);
                }
                if (a == 2)
                {
                    Product product = new Product();
                    product = sellerClient.CreateProduct(companyName);
                    productData.Products.Add(product);
                }
                if (a == 3) 
                {
                    int prId = GetProduct(productData, companyName);
                    sellerClient.DeleteProduct(productData, prId);
                }
            }
            else 
            {
                Product product = new Product();
                product=sellerClient.CreateProduct(companyName);
                productData.Products.Add(product);
            }
        }

        public void UpdateProduct(ProductData productData, int productId, decimal value)
        {
            SellerService sellerService = new SellerService();
            sellerService.UpdateProduct(productData, productId, value);   
        }
        public void DeleteProduct(ProductData productData, int productId)
        {
            SellerService sellerService = new SellerService();
            sellerService.DeleteProduct(productData, productId);
        }


        private int GetProduct(ProductData productData,string companyName)
        {
            Validator validator = new Validator();
            Console.WriteLine("Chose product and enter it`s id:");
            foreach (var item in productData.Products)
            {
                if (item.CompanyName.Equals(companyName))
                {                    
                    Console.WriteLine(item.Id+" "+item.Name);
                }
            }
            string ans = Console.ReadLine();
            int a = validator.IsValidInt(ans);
            return a;
        }
    }
}
