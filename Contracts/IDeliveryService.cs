using FoodDelivery21.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Contracts
{
    public interface IDeliveryService
    {
        void SetDeliveryPrice(DeliveryData deliveryData, string method, decimal price);

        decimal GetDeliveryPrice(DeliveryData deliveryData, string method);
    }
}
