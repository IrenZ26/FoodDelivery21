using FoodDelivery21.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Data
{
    public class DeliveryData
    {
        public IList<Delivery> Deliveries { get; set; }
        public DeliveryData()
        {
            Deliveries = new List<Delivery>();
        }
        public void DeliveryListInit()
        {
            var deliveryCourier = new Delivery("deliver by courier", 15);
            Deliveries.Add(deliveryCourier);
            var deliveryPost = new Delivery("deliver to the post office", 10);
            Deliveries.Add(deliveryPost);
        }
    }
}
