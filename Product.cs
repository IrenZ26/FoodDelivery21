using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Product
    {
        public int Id;
        public string Name;
        public string CompanyName;
        public decimal Price;
        public string DiscountPromoCode;
        public decimal ProductDiscount;
        public decimal PersonalDiscount;

        public object ProductName { get; set; }
        public object ProductPrice { get; set; }

        public Product(object productName, object productPrice, decimal productDiscount, decimal personalDiscount)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductDiscount = productDiscount;
            PersonalDiscount = personalDiscount;
        }

        public void CreateProduct() { }
        public void UpdateProduct() { }
        public void DeleteProduct() { }
        public Product AddProductToOrder()
        {
            var product = new Product(ProductName, ProductPrice, ProductDiscount, PersonalDiscount);
            return product;
        }
    }
}
