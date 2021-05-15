using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    public class BuyerService
    {
        public void CreateOrder()
        {
            var order = new OrderUI();
            order.CreateOrder();
        }
    }
}
