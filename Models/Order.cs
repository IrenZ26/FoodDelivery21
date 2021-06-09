using FoodDelivery21.Data;
using FoodDelivery21.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Order
    {
        public int Id { get; set; }
        public Buyer Buyer { get; set; }
        public Product Product { get; set; }
        public OrderStatus Status { get; set; }
        public decimal ProductValue { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }

        public Order(int id, Product product, decimal productValue, decimal discount, decimal deliveryPrice, decimal totalPrice, OrderStatus status,Buyer buyer)
        {
            Id = id;
            Product = product;           
            ProductValue = productValue;
            Discount = discount;
            DeliveryPrice = deliveryPrice;
            TotalPrice = totalPrice;
            Status = status;
            Buyer = buyer;
        }
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public enum OrderStatus
        {
            Undefined,

            Cancelled,
            Purchased,
            Delivered,
            Packed,
        }
    }
}
