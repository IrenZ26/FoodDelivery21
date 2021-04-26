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
        public decimal AvailableValue { get; set; }
        public string DiscountPromoCode { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal PersonalDiscount { get; set; }

        public Product()
        {         
        }
        public Product(int id, string productName, string companyName, decimal productPrice, decimal availableValue, string discountPromoCode, decimal productDiscount, decimal personalDiscount)
        {
            Id = id;
            Name = productName;
            CompanyName = companyName;
            Price = productPrice;
            AvailableValue = availableValue;
            DiscountPromoCode = discountPromoCode;
            ProductDiscount = productDiscount;
            PersonalDiscount = personalDiscount;
        }
    }
}
