using FoodDelivery21.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Contracts
{
    public interface IOrderService
    {
        void SetDeliveryPrice(Buyer buyer, decimal deliveryPrice);

        decimal GetDeliveryPrice(Buyer buyer);
    }
}
