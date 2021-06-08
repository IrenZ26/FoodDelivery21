﻿using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class OrderService
    {
        public Order AddOrderItem(ProductData productData, ProductData cacheProductData, Buyer buyer, int id)
        {
            var product = new Product();
            var productUI = new ProductUI();
            product = productUI.AddProductToOrder(cacheProductData);
            var buyerClient = new BuyerInterface();
            var orderUI = new OrderUI();
            var totalPrice = product.Price;
            var val = orderUI.GetItemsCount();
            var value = productUI.UpdateProduct(productData,product.Id, val,"dec");
            totalPrice *= value;
            var promo = buyerClient.GetPromo();
            var discount = product.ProductDiscount;
            if (product.DiscountPromoCode.Equals(promo))
            {
                discount += product.PersonalDiscount;
            }
            else { }
            totalPrice = GetDiscount(totalPrice, discount);
            var order = new Order(id,product, value, discount, 0.0m, totalPrice, Order.OrderStatus.Undefined, buyer);
            return order;
        }

        private decimal GetDiscount(decimal price, decimal discount)
        {
            decimal result = Math.Round(price - (price * discount), 2);
            return result;
        }
        public void UpdateOrder() { }
        public void DeleteOrder() { }
    }
}
