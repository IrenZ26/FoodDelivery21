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
            Product product = new Product(productName, companyName, price, promoCode, productDiscount, personalDiscount);
            return product;
        }
        public void UpdateProduct() { }
        public void DeleteProduct() { }
        public Product AddProductToOrder()
        {
            var product = new Product();
            return product;
        }
    }
}
