using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
    public class OrderUI
    {  
        public void CreateOrder(DeliveryData deliveryData,OrderData orderData,ProductData productData)
        {
            bool isContinue = true;
            var buyerClient = new BuyerInterface();
            var orderService = new OrderService();
            while (isContinue)
            {
                orderData.Orders.Add(orderService.AddOrderItem(productData,1));
                isContinue = buyerClient.Continue();
            }
            decimal totalPrice = 0;
            var delivery = new DeliveryUI();
            totalPrice += delivery.GetDelivery(deliveryData);
            buyerClient.ShowOrder(orderData, totalPrice);
        }

        public decimal GetItemsCount()
        {
            var buyer = new BuyerInterface();
            string answer = buyer.ItemsMassage();
            var validator = new Validator();
            decimal val = validator.CheckDecimal(answer);
            return val;
        }
    }
}
