using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class DeliveryService
    {
        public decimal GetDelivery()
        {
            var deliveryData = new DeliveryData();
            deliveryData.DeliveryListInit();
            decimal price = default;
            var buyerClient = new BuyerClient();
            int k = buyerClient.ShowDelivery(deliveryData);
            price = GetDeliveryPrice(deliveryData.Deliveries[k - 1].Method);
            return price;
        }
        public void SetDeliveryPrice(string Method, decimal Price)
        {
            var deliveryData = new DeliveryData();
            var delivery = new Delivery(Method, Price);
            deliveryData.Deliveries.Add(delivery);
        }
        public decimal GetDeliveryPrice(string Method)
        {
            var deliveryData = new DeliveryData();
            deliveryData.DeliveryListInit();
            decimal price = default;
            foreach (var item in deliveryData.Deliveries)
            {
                if (item.Method == Method) { price = item.Price; }
            }
            return price;
        }
    }
}
