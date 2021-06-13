using FoodDelivery21.Contracts;
using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class OrderService: IOrderService
    {
        private readonly IOrderData _orderData;
        private readonly IProductData _productData;
        private readonly IDeliveryData _deliveryData;
        public OrderService(IOrderData orderData, IProductData productData,IDeliveryData deliveryData)
        {
            _orderData = orderData;
            _productData = productData;
            _deliveryData = deliveryData;
        }

        public void SetDeliveryPrice(Buyer buyer, decimal deliveryPrice)
        {
            foreach (var item in _orderData.Orders)
            {
                item.DeliveryPrice = deliveryPrice;
            }
        }

        public decimal GetDeliveryPrice(Buyer buyer)
        {
            decimal result = 0;
            int id = 0;
            foreach (var item in _orderData.Orders)
            {
                if ((item.Buyer.Name == buyer.Name) && (item.Buyer.Address == buyer.Address) && (item.Buyer.Telephone == buyer.Telephone))
                {
                    if (item.Id == id)
                    {
                        result += item.DeliveryPrice;
                        id = item.Id + 1;
                    }
                }
            }
            return result;
        }
    }

}
