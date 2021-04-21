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
        public IList<Product> Products { get; set; }

        public Product()
        {
            Products = new List<Product>();
        }
        public Product(int productId, string productName, string companyName, decimal productPrice, string discountPromoCode, decimal productDiscount, decimal personalDiscount)
        {
            Id = productId;
            Name = productName;
            CompanyName = companyName;
            Price = productPrice;
            DiscountPromoCode = discountPromoCode;
            ProductDiscount = productDiscount;
            PersonalDiscount = personalDiscount;
        }
        public void CreateProduct() { }
        public void UpdateProduct() { }
        public void DeleteProduct() { }
        public Product AddProductToOrder()
        {
            var product = new Product(Id,Name, CompanyName, Price, DiscountPromoCode, ProductDiscount, PersonalDiscount);
            return product;
        }
    }
}
