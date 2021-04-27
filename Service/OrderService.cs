using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class OrderService
    {
        public void CreateOrder()
        {
            bool f = true;
            BuyerClient buyerClient = new BuyerClient();
            OrderData orderData = new OrderData();
            ProductData productData = new ProductData();
            productData.ProductsInit();
            while (f)
            {
                orderData.Orders.Add(AddOrderItem(productData));
                f = buyerClient.Continue();
            }
            decimal totalPrice = 0;
            DeliveryService deliveryService = new DeliveryService();
            totalPrice += deliveryService.GetDelivery();
            
            buyerClient.ShowOrder(orderData, totalPrice);            
        }
        public Order AddOrderItem(ProductData productData)
        {
            Product product = new Product();
            ProductService productService = new ProductService();
            product = productService.AddProductToOrder(productData);
            BuyerClient buyerClient = new BuyerClient();
            decimal totalPrice = product.Price;
            decimal val = buyerClient.GetItemsCount();
            decimal value = productService.UpdateProduct(productData,product.Id, val,"dec");
            totalPrice *= value;
            string promo = buyerClient.GetPromo();
            decimal discount = product.ProductDiscount;
            if (product.DiscountPromoCode.Equals(promo))
            {
                discount += product.PersonalDiscount;
            }
            else { }
            totalPrice = GetDiscount(totalPrice, discount);
            Order order = new Order(product, value, discount, totalPrice);
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
