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
        public string ProductName { get; set; }
        public int ProductValue { get; set; }
        public decimal ProductPrice { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal PrivateDiscount { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal TotalPrice { get; set; }

        public void CreateOrder() { }
        public void UpdateOrder() { }
        public void DeleteOrder() { }
    }
}
