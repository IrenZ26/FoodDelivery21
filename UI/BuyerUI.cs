using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
    public class BuyerUI
    {
        public  Buyer CreateBuyer(string name, string address, string telephone)
        {
            var buyer = new Buyer(name, address, telephone);
            return buyer;
        }
        public bool IsExist(OrderData orderData, Buyer buyer)
        {
            var result = false;
           
            foreach (var item in orderData.Orders)
            {
                if ((item.Buyer.Name == buyer.Name)&& (item.Buyer.Address == buyer.Address) && (item.Buyer.Telephone == buyer.Telephone)){ result = true; }
            }
            return result;
        }
        public void CreateOrder(DeliveryData deliveryData, OrderData orderData, ProductData productData, Buyer buyer)
        {
            bool isExist = IsExist(orderData, buyer);
            var answer = 2;
            var order = new OrderUI();
            if (isExist) 
            { 
                answer = GetResult();
            }
            if (answer == 1) 
            {
                var buyerClient = new BuyerInterface();
                buyerClient.ShowOrder(orderData, default, buyer,false);
            }
            if (answer == 2) 
            {
                order.CreateOrder(deliveryData, orderData, productData, buyer);
                var initializator = new Initializator();
                initializator.SerializeOrders(orderData);
            }
        }
        public int GetResult()
        {
            var buyer = new BuyerInterface();
            var answer = buyer.ExistMassage();
            var validator = new Validator();
            var result = validator.IntValidation(answer);
            return result;
        }
    }
}
