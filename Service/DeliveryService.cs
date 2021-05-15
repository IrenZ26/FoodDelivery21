using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class DeliveryService
    {
        public void SetDeliveryPrice(string Method, decimal Price)
        {
            var deliveryData = new DeliveryData();
            var delivery = new Delivery(Method, Price);
            deliveryData.Deliveries.Add(delivery);
        }
        public decimal GetDeliveryPrice(DeliveryData deliveryData, string Method)
        {
            decimal price = default;
            foreach (var item in deliveryData.Deliveries)
            {
                if (item.Method == Method) { price = item.Price; }
            }
            return price;
        }
    }
}
