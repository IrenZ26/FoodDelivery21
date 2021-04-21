using System;
using System.Collections.Generic;

namespace FoodDelivery21
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
        public string DiscountPromoCode { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal PersonalDiscount { get; set; }
        public IList<Product> Products { get; set; }

        public Product()
        {
            Products = new List<Product>();
        }
        private void ProductsInit() 
        {
            Product product = new Product("Milk", "Milk factory", 12, "white", 0.1m, 0.12m);
            Products.Add(product);
            Product product1 = new Product("Bread", "Backery", 10, "", 0.05m, 0);
            Products.Add(product1);
            Product product2 = new Product("Eggs", "Newton`s farm", 15, "chicken", 0, 0.1m);
            Products.Add(product2);
        }
        public Product(string productName, string companyName, decimal productPrice, string discountPromoCode, decimal productDiscount, decimal personalDiscount)
        {
            Name = productName;
            CompanyName = companyName;
            Price = productPrice;
            DiscountPromoCode = discountPromoCode;
            ProductDiscount = productDiscount;
            PersonalDiscount = personalDiscount;
        }
        public Product CreateProduct()
        {
            Console.WriteLine("Enter product name");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter company name");
            string companyName = Console.ReadLine();
            Console.WriteLine("Enter company price");
            string s = Console.ReadLine().Replace(".", ",");
            decimal price = 0;
            try
            {
                price = decimal.Parse(s);
            }
            catch (FormatException)
            {

                Console.WriteLine("Input Error");
            }
            Console.WriteLine("Enter discount promo code");
            string promoCode = Console.ReadLine();
            Console.WriteLine("Enter product discount");
            string s1 = Console.ReadLine().Replace(".", ",");
            decimal productDiscount = 0;
            try
            {
                productDiscount = decimal.Parse(s1);
            }
            catch (FormatException)
            {

                Console.WriteLine("Input Error");
            }
            Console.WriteLine("Enter personal discount");
            string s2 = Console.ReadLine().Replace(".", ",");
            decimal personalDiscount = 0;
            try
            {
                personalDiscount = decimal.Parse(s2);
            }
            catch (FormatException)
            {

                Console.WriteLine("Input Error");
            }
            Product product = new Product(productName, companyName, price, promoCode, productDiscount, personalDiscount);
            return product;
        }
        public void UpdateProduct() { }
        public void DeleteProduct() { }
        public Product AddProductToOrder()
        {
            ProductsInit();
            foreach(var item in Products) 
            {
                Console.WriteLine(item.Name + " from " + item.CompanyName + " costs " + item.Price + "$");
            }
            Console.WriteLine("Enter products`s id");
            string ans = Console.ReadLine();
            int k = 1;
            try
            {
                k = int.Parse(ans);
            }
            catch (FormatException)
            {

                Console.WriteLine("Input Error");
            }
            var product = Products[k-1];
            return product;
        }
    }
}
