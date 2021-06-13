using FoodDelivery21.Contracts;
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
        private readonly IOrderData _orderData;
        private readonly IProductData _productData;
        private readonly IDeliveryData _deliveryData;
        public OrderUI(IOrderData orderData, IProductData productData, IDeliveryData deliveryData)
        {
            _orderData = orderData;
            _productData = productData;
            _deliveryData = deliveryData;
        }
        public decimal GetItemsCount()
        {
            var buyer = new ByuerInterface();
            string answer = buyer.ItemsMassage();
            decimal result;
            decimal.TryParse(answer, out result);
            return result;
        }

        public Order AddOrderItem(int id)
        {
            var product = new Product();
            var productService = new ProductUI(_productData);
            product = productService.AddProductToOrder();
            var buyerClient = new ByuerInterface();
            var totalPrice = product.Price;
            var val = GetItemsCount();
            var value = productService.UpdateProduct(product.Id, val, "dec");
            totalPrice *= value;
            var promo = buyerClient.GetPromo();
            var discount = product.ProductDiscount;
            if (product.DiscountPromoCode.Equals(promo))
            {
                discount += product.PersonalDiscount;
            }
            totalPrice = GetDiscount(totalPrice, discount);
            var order = new Order(id, product, value, discount, 0.0m, totalPrice);
            return order;
        }

        private decimal GetDiscount(decimal price, decimal discount)
        {
            decimal result = Math.Round(price - (price * discount), 2);
            return result;
        }

        public void CreateOrder()
        {
            bool isContinue = true;
            var buyerClient = new ByuerInterface(_orderData);
            while (isContinue)
            {
                _orderData.Orders.Add(AddOrderItem(1));
                isContinue = buyerClient.Continue();
            }
            decimal totalPrice = 0;
            var delivery = new DeliveryUI(_deliveryData);
            totalPrice += delivery.GetDelivery();
            buyerClient.ShowOrder(totalPrice);
        }

        public void CreateOrder(Buyer buyer)
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
                CreateOrder();
            }
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
