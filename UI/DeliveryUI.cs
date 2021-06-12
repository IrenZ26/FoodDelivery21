using FoodDelivery21.Data;
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
            int result;
            int.TryParse(answer, out result);
            return result;
        }

        public decimal GetDelivery(DeliveryData deliveryData)
        {
            decimal price = default;
            var delivery = new DeliveryService();
            int k = ShowDelivery(deliveryData);
            price = delivery.GetDeliveryPrice(deliveryData, deliveryData.Deliveries[k - 1].Method);
            return price;
        }

        public void SetDeliveryPrice(OrderData orderData, Buyer buyer, decimal deliveryPrice)
        {
            foreach (var item in orderData.Orders)
            {
                item.DeliveryPrice = deliveryPrice;
            }
        }

        public decimal GetDeliveryPrice(OrderData orderData, Buyer buyer)
        {
            decimal result = 0;
            int id = 0;
            foreach (var item in orderData.Orders)
            {
                if ((item.Buyer.Name == buyer.Name) && (item.Buyer.Address == buyer.Address) && (item.Buyer.Telephone == buyer.Telephone))
                {
                    if (item.Id == id)
                        {
                            result += item.DeliveryPrice;
                            id = item.Id+1;
                        }
                }
            }
            return result;
        }
    }
}
