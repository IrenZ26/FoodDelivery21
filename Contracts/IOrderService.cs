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
        decimal GetDeliveryPrice(Buyer buyer);

        void CreateOrder(Order order);

        void ShowOrder(decimal totalPrice, Buyer buyer, bool isCreate);
    }
}
