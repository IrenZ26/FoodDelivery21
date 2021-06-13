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
        public void CreateOrder(Order order) 
        {
            _orderData.Orders.Add(order);
        }

        public void ShowOrder(decimal totalPrice, Buyer buyer, bool isCreate)
        {
            if (!isCreate)
            {
                totalPrice += GetDeliveryPrice(buyer);
            }

            Console.WriteLine("Your order: ");
            foreach (var item in _orderData.Orders)
            {
                var discount = item.Discount * 100;
                Console.WriteLine(item.Product.Name + " " + item.ProductValue + " items, costs " + item.Product.Price + "$ for one item.\nDiscount = " + discount + "%. Total price = " + item.TotalPrice + "$");
                totalPrice += item.TotalPrice;
            }
            Console.WriteLine("Total price of the whole order with delivery = " + totalPrice + "$");
        }
        public decimal GetDeliveryPrice(Buyer buyer)
        {
            decimal result = 0;
            int id = 0;
            foreach (var item in _orderData.Orders)
            {
                if ((item.Buyer.Name == buyer.Name) && (item.Buyer.Address == buyer.Address) && (item.Buyer.Telephone == buyer.Telephone))
                {
                    if ((item.Status != Order.OrderStatus.Undefined))
                    {
                        if (item.Id == id)
                        {
                            result += item.DeliveryPrice;
                            id = item.Id + 1;
                        }
                    }
                }
            }
            return result;
        }
    }

}
