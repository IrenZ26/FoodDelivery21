﻿using FoodDelivery21.Data;
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
        public int ShowDelivery(DeliveryData deliveryData)
        {
            var byer = new BuyerInterface();
            var answer = byer.ShowDeliveries(deliveryData);
<<<<<<< HEAD
            var validator = new Validator();
            var result = validator.CheckInt(answer);
            return result;
        }

=======
            int result;
            int.TryParse(answer, out result);
            return result;
        }
>>>>>>> regexValidation
        public decimal GetDelivery(DeliveryData deliveryData)
        {
            deliveryData.DeliveryListInit();
            decimal price = default;
            var delivery = new DeliveryService();
            int k = ShowDelivery(deliveryData);
            price = delivery.GetDeliveryPrice(deliveryData, deliveryData.Deliveries[k - 1].Method);
            return price;
        }
    }
}
