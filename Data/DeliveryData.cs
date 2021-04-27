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
            Delivery delivery = new Delivery("deliver by courier", 15);
            Deliveries.Add(delivery);
            Delivery delivery1 = new Delivery("deliver to the post office", 10);
            Deliveries.Add(delivery1);
        }
    }
}
