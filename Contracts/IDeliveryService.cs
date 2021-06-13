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
        void SetDeliveryPrice(string method, decimal price);

        void ShowDeliveries();
        decimal GetDeliveryPrice(int id);
    }
}
