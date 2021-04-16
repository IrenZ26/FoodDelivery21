using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Order
    {
        public int Id;
        public string ProductName;
        public int ProductValue;
        public decimal ProductPrice;
        public string DeliveryMethod;
        public decimal DeliveryPrice;
        public decimal PrivateDiscount;
        public decimal ProductDiscount;
        public decimal TotalPrice;

        public void CreateOrder() { }
        public void UpdateOrder() { }
        public void DeleteOrder() { }
    }
}
