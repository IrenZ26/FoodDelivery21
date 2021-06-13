using FoodDelivery21.Contracts;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
    public class DeliveryService
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        public DeliveryService(IOrderService orderService, IProductService productService, IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
            _orderService = orderService;
            _productService = productService;
        }

        public int ShowDelivery()
        {
            var byer = new ByuerInterface(_orderService,_productService,_deliveryService);
            var answer = byer.ShowDeliveries();
            int result;
            int.TryParse(answer, out result);
            return result;
        }

        public decimal GetDelivery()
        {
            decimal price = default;
            int id = ShowDelivery();
            price = _deliveryService.GetDeliveryPrice(id-1);
            return price;
        }
    }
}
