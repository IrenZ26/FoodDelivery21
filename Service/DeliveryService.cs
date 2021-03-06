using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class DeliveryService
    {
        public void SetDeliveryPrice(DeliveryData deliveryData, string method, decimal price)
        {
            var delivery = new Delivery(method, price);
            deliveryData.Deliveries.Add(delivery);
        }

        public decimal GetDeliveryPrice(DeliveryData deliveryData, string method)
        {
            decimal price = default;
            foreach (var delivery in deliveryData.Deliveries)
            {
                if (delivery.Method == method) 
                {
                    price = delivery.Price; 
                }
            }
            return price;
        }
    }
}
