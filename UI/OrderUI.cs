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
        private readonly IDeliveryService _deliveryService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IBuyerService _buyerService;
        public OrderUI(IOrderService orderService, IProductService productService,IDeliveryService deliveryService,IBuyerService buyerService)
        {
            _deliveryService = deliveryService;
            _orderService = orderService;
            _productService = productService;
            _buyerService = buyerService;
        }

        public decimal GetItemsCount()
        {
            var buyer = new ByuerInterface();
            string answer = buyer.ItemsMessage();
            decimal result;
            decimal.TryParse(answer, out result);
            return result;
        }

        public Order AddOrderItem(Buyer buyer,int id)
        {
            var product = new Product();
            var productUI = new ProductUI(_orderService,_productService,_deliveryService);
            product = productUI.AddProductToOrder();
            var buyerClient = new ByuerInterface();
            var totalPrice = product.Price;
            var val = GetItemsCount();
            var value = productUI.UpdateProduct(product.Id, val, "dec");
            totalPrice *= value;
            var promo = buyerClient.GetPromo();
            var discount = product.ProductDiscount;
            if (product.DiscountPromoCode.Equals(promo))
            {
                discount += product.PersonalDiscount;
            }
            totalPrice = GetDiscount(totalPrice, discount);
            var order = new Order(id, product, value, discount, 0.0m, totalPrice,buyer,Order.OrderStatus.Undefined);
            return order;
        }

        private decimal GetDiscount(decimal price, decimal discount)
        {
            decimal result = Math.Round(price - (price * discount), 2);
            return result;
        }

        public void CreateOrder(Buyer buyer)
        {
            bool isContinue = true;
            var buyerClient = new ByuerInterface(_orderService,_productService,_deliveryService);
            while (isContinue)
            {
                var order = AddOrderItem(buyer,1);
                _orderService.CreateOrder(order);
                isContinue = buyerClient.Continue();
            }
            decimal totalPrice = 0;
            var delivery = new DeliveryService(_orderService,_productService,_deliveryService);
            totalPrice += delivery.GetDelivery();
            _orderService.ShowOrder(totalPrice,buyer,true);
        }

        public void Create(Buyer buyer)
        {
            bool isExist = _buyerService.IsExist(buyer);
            var answer = 2;
            if (isExist)
            {
                answer = GetResult();
            }
            if (answer == 1)
            {
                var buyerClient = new ByuerInterface(_orderService,_productService,_deliveryService);
                _orderService.ShowOrder(default,buyer,false);
            }
            if (answer == 2)
            {
                CreateOrder(buyer);
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
