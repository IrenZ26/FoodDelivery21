using FoodDelivery21.Contracts;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
    public class ProductUI
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public ProductUI(IOrderService orderService, IProductService productService, IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
            _orderService = orderService;
            _productService = productService;
        }

        public decimal UpdateProduct(int productId, decimal value, string action)
        {
            decimal result = 0;
            if (action == "dec")
            {
                var isEnough = _productService.DecrementProducts(value, out value, productId);
                if (!isEnough)
                {
                    ByuerInterface buyerClient = new ByuerInterface();
                    buyerClient.ShowQuantErrMessage(value);
                }
                result = value;
            }
            if (action == "inc")
            {
                result = _productService.IncrementProducts(value, productId);
            }
            return result;
        }

        public Product AddProductToOrder()
        {
            int id = GetProductId();
            var product = _productService.GetProduct(id - 1);
            return product;
        }

        public int GetProductId()
        {
            var buyer = new ByuerInterface(_orderService, _productService, _deliveryService);
            var answer = buyer.ShowProducts();
            int result;
            int.TryParse(answer, out result);
            return result;
        }
    }
}
