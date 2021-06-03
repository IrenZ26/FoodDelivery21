using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class OrderService
    {
        public Order AddOrderItem(ProductData productData)
        {
            var product = new Product();
            var productUI = new ProductUI();
            product = productUI.AddProductToOrder(productData);
            var buyerClient = new BuyerInterface();
            var orderUI = new OrderUI();
            var totalPrice = product.Price;
            var val = orderUI.GetItemsCount();
            var logger = new Logger();
            logger.SaveIntoFile(product.Name + " was added to the order");
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
            var order = new Order(product, value, discount, totalPrice);
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
