using FoodDelivery21.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Data
{
    public class OrderData:IOrderData
    {
        public IList<Order> Orders { get; set; }

        public OrderData()
        {
            Orders = new List<Order>();
        }
    }
}
