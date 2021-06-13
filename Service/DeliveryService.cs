using FoodDelivery21.Contracts;
using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class DeliveryService: IDeliveryService
    {
        private readonly IDeliveryData _deliveryData;
        public DeliveryService(IDeliveryData deliveryData)
        {
            _deliveryData = deliveryData;
        }
        public void SetDeliveryPrice(string method, decimal price)
        {
            var delivery = new Delivery(method, price);
            _deliveryData.Deliveries.Add(delivery);
        }
        public string GetMethod(int id)
        {
            return _deliveryData.Deliveries[id].Method;
        }
        public void ShowDeliveries()
        {
            foreach (var item in _deliveryData.Deliveries)
            {
                Console.WriteLine(item.Method + " costs " + item.Price + "$");
            }
        }

        public decimal GetDeliveryPrice(int id)
        {
            var method = GetMethod(id);
            decimal price = default;
            foreach (var delivery in _deliveryData.Deliveries)
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
