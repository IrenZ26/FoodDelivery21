using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Product(string productName, decimal productPrice, decimal productDiscount, decimal personalDiscount)
        {
            Name = productName;
            Price = productPrice;
            ProductDiscount = productDiscount;
            PersonalDiscount = personalDiscount;
        }

        public void CreateProduct() { }
        public void UpdateProduct() { }
        public void DeleteProduct() { }
        public Product AddProductToOrder()
        {
            var product = new Product(Name, Price, ProductDiscount, PersonalDiscount);
            return product;
        }
    }
}
