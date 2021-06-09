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
<<<<<<< HEAD
            bool isContinue = true;
=======
            bool f = true;
>>>>>>> regexValidation
            var buyerClient = new BuyerInterface();
            var orderData = new OrderData();
            var productData = new ProductData();
            var orderService = new OrderService();
            productData.ProductsInit();
<<<<<<< HEAD
            while (isContinue)
            {
                orderData.Orders.Add(orderService.AddOrderItem(productData));
                isContinue = buyerClient.Continue();
=======
            while (f)
            {
                orderData.Orders.Add(orderService.AddOrderItem(productData));
                f = buyerClient.Continue();
>>>>>>> regexValidation
            }
            decimal totalPrice = 0;
            var delivery = new DeliveryUI();
            var deliveryData = new DeliveryData();
            totalPrice += delivery.GetDelivery(deliveryData);

            buyerClient.ShowOrder(orderData, totalPrice);
        }
<<<<<<< HEAD

=======
>>>>>>> regexValidation
        public decimal GetItemsCount()
        {
            var buyer = new BuyerInterface();
            string answer = buyer.ItemsMassage();
<<<<<<< HEAD
            var validator = new Validator();
            decimal val = validator.CheckDecimal(answer);
            return val;
=======
            decimal result;
            decimal.TryParse(answer, out result);
            return result;
>>>>>>> regexValidation
        }
    }
}
