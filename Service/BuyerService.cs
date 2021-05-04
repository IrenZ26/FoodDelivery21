using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class BuyerService
    {
        public void CreateOrder()
        {
            var order = new OrderService();
            order.CreateOrder();
        }
        public void UpdateOrder() { }
        public void DeleteOrder() { }
    }
}
