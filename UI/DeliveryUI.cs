using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
    class DeliveryUI
    {
        public int ShowDelivery(DeliveryData deliveryData)
        {
            var byer = new BuyerInterface();
            var answer = byer.ShowDeliveries(deliveryData);
            var validator = new Validator();
            var result = validator.IntValidation(answer);            
            return result;
        }
        public decimal GetDelivery(DeliveryData deliveryData)
        {
            deliveryData.DeliveryListInit();
            decimal price = default;
            var delivery = new DeliveryService();
            int k = ShowDelivery(deliveryData);
            price = delivery.GetDeliveryPrice(deliveryData, deliveryData.Deliveries[k - 1].Method);
            var logger = new Logger();
            var loggerMassage = "The delivery method was selected as " + deliveryData.Deliveries.ElementAt(k-1).Method;
            logger.SaveIntoFile(loggerMassage);
            return price;
        }
    }
}
