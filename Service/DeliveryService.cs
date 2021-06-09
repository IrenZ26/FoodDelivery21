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
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> regexValidation
=======

>>>>>>> logger
        public decimal GetDeliveryPrice(DeliveryData deliveryData, string method)
        {
            decimal price = default;
            foreach (var delivery in deliveryData.Deliveries)
            {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                if (delivery.Method == method) 
                {
                    price = delivery.Price; 
                }
=======
                if (item.Method == method) { price = item.Price; }
>>>>>>> regexValidation
=======
                if (item.Method == method) { price = item.Price; }
>>>>>>> logger
=======
                if (delivery.Method == method) { price = delivery.Price; }
>>>>>>> jsonSerialization
            }
            return price;
        }
    }
}
