using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    class BuyerService
    {
        public void CreateOrder()
        {
            OrderService order = new OrderService();
            order.CreateOrder();
        }
        public void UpdateOrder() { }
        public void DeleteOrder() { }
    }
}
