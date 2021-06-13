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
        public OrderService(IOrderData orderData)
        {
            _orderData = orderData;
        }

        public Order AddOrderItem(ProductData productData, int id)
        {
            var product = new Product();
            var productUI = new ProductService(productData);
            product = productUI.AddProductToOrder();
            var buyerClient = new ByuerInterface();
            var totalPrice = product.Price;
            var val = GetItemsCount();
            var value = productUI.UpdateProduct(product.Id, val,"dec");
            totalPrice *= value;
            var promo = buyerClient.GetPromo();
            var discount = product.ProductDiscount;
            if (product.DiscountPromoCode.Equals(promo))
            {
                discount += product.PersonalDiscount;
            }
            totalPrice = GetDiscount(totalPrice, discount);
            var order = new Order(id,product, value, discount, 0.0m, totalPrice);
            return order;
        }

        private decimal GetDiscount(decimal price, decimal discount)
        {
            decimal result = Math.Round(price - (price * discount), 2);
            return result;
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

        public decimal GetItemsCount()
        {
            var buyer = new ByuerInterface();
            string answer = buyer.ItemsMassage();
            decimal result;
            decimal.TryParse(answer, out result);
            return result;
        }

        public void CreateOrder(DeliveryData deliveryData, ProductData productData)
        {
            bool isContinue = true;
            var buyerClient = new ByuerInterface(_orderData);
            while (isContinue)
            {
                _orderData.Orders.Add(AddOrderItem(productData, 1));
                isContinue = buyerClient.Continue();
            }
            decimal totalPrice = 0;
            var delivery = new DeliveryService(deliveryData);
            totalPrice += delivery.GetDelivery();
            buyerClient.ShowOrder(totalPrice);
        }

        public bool IsExist(Buyer buyer)
        {
            var result = false;

            foreach (var item in _orderData.Orders)
            {
                if ((item.Buyer.Name == buyer.Name) && (item.Buyer.Address == buyer.Address) && (item.Buyer.Telephone == buyer.Telephone)) { result = true; }
            }
            return result;
        }

        public void CreateOrder(DeliveryData deliveryData, ProductData productData, Buyer buyer)
        {
            bool isExist = IsExist(buyer);
            var answer = 2;
            if (isExist)
            {
                answer = GetResult();
            }
            if (answer == 1)
            {
                var buyerClient = new ByuerInterface(_orderData);
                buyerClient.ShowOrder(default);
            }
            if (answer == 2)
            {
                CreateOrder(deliveryData, productData);
            }
        }

        public int GetResult()
        {
            var buyer = new ByuerInterface();
            var answer = buyer.ExistMessage();
            int result;
            int.TryParse(answer, out result);
            return result;
        }
    }

}
