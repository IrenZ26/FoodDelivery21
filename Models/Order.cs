using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Order
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public decimal ProductValue { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }

        public Order(Product product, decimal productValue, decimal discount, decimal totalPrice)
        {
            Product = product;           
            ProductValue = productValue;
            Discount = discount;
            TotalPrice = totalPrice;
        }
    }
}
