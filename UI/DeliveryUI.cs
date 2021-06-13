using FoodDelivery21.Contracts;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
    public class DeliveryUI
    {
        private readonly IDeliveryData _deliveryData;
        public DeliveryUI(IDeliveryData deliveryData)
        {
            _deliveryData = deliveryData;
        }
        public int ShowDelivery()
        {
            var byer = new ByuerInterface(_deliveryData);
            var answer = byer.ShowDeliveries();
            int result;
            int.TryParse(answer, out result);
            return result;
        }

        public decimal GetDelivery()
        {
            decimal price = default;
            int k = ShowDelivery();
            var delivery = new DeliveryService(_deliveryData);
            price = delivery.GetDeliveryPrice(_deliveryData.Deliveries[k - 1].Method);
            return price;
        }
    }
}
