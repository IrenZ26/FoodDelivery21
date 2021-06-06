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
        public void CreateOrder()
        {
            bool isContinue = true;
            var buyerClient = new BuyerInterface();
            var orderData = new OrderData();
            var productData = new ProductData();
            var orderService = new OrderService();
            productData.ProductsInit();
            while (isContinue)
            {
                orderData.Orders.Add(orderService.AddOrderItem(productData));
                isContinue = buyerClient.Continue();
            }
            decimal totalPrice = 0;
            var delivery = new DeliveryUI();
            var deliveryData = new DeliveryData();
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
