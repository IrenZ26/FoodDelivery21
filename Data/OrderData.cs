using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Data
{
    public class OrderData
    {
        public IList<Order> Orders { get; set; }

        public OrderData()
        {
            Orders = new List<Order>();
        }
    }
}
