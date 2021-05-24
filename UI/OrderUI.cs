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
            bool f = true;
            var buyerClient = new BuyerInterface();
            var orderData = new OrderData();
            var productData = new ProductData();
            var orderService = new OrderService();
            productData.ProductsInit();
            while (f)
            {
                orderData.Orders.Add(orderService.AddOrderItem(productData));
                f = buyerClient.Continue();
            }
            decimal totalPrice = 0;
            var delivery = new DeliveryUI();
            var deliveryData = new DeliveryData();
            totalPrice += delivery.GetDelivery(deliveryData);
            var logger = new Logger();
            var loggerMassage = "The total order`s price was calculated";
            logger.SaveIntoFile(loggerMassage);
            buyerClient.ShowOrder(orderData, totalPrice);
        }
        public decimal GetItemsCount()
        {
            var buyer = new BuyerInterface();
            string answer = buyer.ItemsMassage();
            var validator = new Validator();
            decimal val = validator.DecimalValidation(answer);
            return val;
        }
    }
}
