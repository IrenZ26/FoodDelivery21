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
        public void CreateOrder(DeliveryData deliveryData,OrderData orderData,ProductData productData, Buyer buyer)
        {
            bool isContinue = true;
            var buyerClient = new BuyerInterface();
            var orderService = new OrderService();
            var delivery = new DeliveryUI();
            int id = GetId(orderData);
            while (isContinue)
            {
                orderData.Orders.Add(orderService.AddOrderItem(productData, buyer, id));
                isContinue = buyerClient.Continue();
            }
            decimal totalPrice = delivery.GetDeliveryPrice(orderData, buyer);
            decimal deliveryPrice = delivery.GetDelivery(deliveryData);
            delivery.SetDeliveryPrice(orderData, buyer, deliveryPrice);
            totalPrice += deliveryPrice;
            buyerClient.ShowOrder(orderData, totalPrice, buyer, true);
            var logger = new Logger();
            logger.SaveIntoFile("The total order`s price was calculated");
        }

        public int GetId(OrderData orderData)
        {
            int result = 0;
            foreach (var item in orderData.Orders)
            {
                result = item.Id+1;
            }
            return result;
        }

        public int GetOrderID(OrderData orderData, string companyName)
        {
            var seller = new SellerInterface();
            var answer = seller.ShowOrdersStatus(orderData, companyName);
            int result;
            int.TryParse(answer, out result);
            return result;
        }

        public int GetNewStatus()
        {
            var seller = new SellerInterface();
            var answer = seller.ShowStatusMessage();
            int result;
            int.TryParse(answer, out result);
            return result;
        }

        public void SetNewStatus(OrderData orderData, int id, int status)
        {
            foreach (var item in orderData.Orders)
            {
                if (item.Id == id)
                {
                    switch (status)
                    {
                        case 1:
                            item.Status = Order.OrderStatus.Cancelled;
                            break;
                        case 2:
                            item.Status = Order.OrderStatus.Packed;
                            break;
                        case 3:
                            item.Status = Order.OrderStatus.Delivered;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public decimal GetItemsCount()
        {
            var buyer = new BuyerInterface();
            string answer = buyer.ItemsMassage();
            decimal result;
            decimal.TryParse(answer, out result);
            return result;
        }
    }
}
