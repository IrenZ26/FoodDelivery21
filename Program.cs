using FoodDelivery21.Data;
using FoodDelivery21.Service;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodDelivery21
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var deliveryData = new DeliveryData();
            deliveryData.DeliveryListInit();
            var productData = new ProductData();
            productData.ProductsInit();
            var deliveryService = new Service.DeliveryService(deliveryData);
            var productService = new ProductService(productData);
            var orderData = new OrderData();
            var orderService = new OrderService(orderData, productData, deliveryData);
            var sellerService = new SellerService(productData);
            var byerService = new BuyerService(orderData);
            var identification = new Identification(orderService, productService, deliveryService,sellerService,byerService);

            identification.Start();
        }
    }
}
