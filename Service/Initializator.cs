using FoodDelivery21.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Service
{
    public class Initializator
    {
        private const string delivery = "Delivery.json";
        private const string orders = "Orders.json";
        private const string products = "Products.json";

        public DeliveryData DeserializeDelivery()
        {
            var deliveryData = new DeliveryData();
            if(File.Exists(delivery))
            {
                deliveryData = JsonConvert.DeserializeObject<DeliveryData>(File.ReadAllText(delivery)); 
            }
            else { deliveryData.DeliveryListInit(); }
            return deliveryData;
        }
        public void SerializeDelivery(DeliveryData deliveryData)
        {
            File.WriteAllText(delivery, JsonConvert.SerializeObject(deliveryData));
        }
        public OrderData DeserializeOrders() 
        {
            var orderData = new OrderData();
            if (File.Exists(orders))
            {
                orderData = JsonConvert.DeserializeObject<OrderData>(File.ReadAllText(orders));
            }
            return orderData;
        }
        public void SerializeOrders(OrderData orderData)
        {
            File.WriteAllText(orders, JsonConvert.SerializeObject(orderData));
        }
        public ProductData DeserializeProducts()
        {
            var productData = new ProductData();
            if (File.Exists(products))
            {
                productData = JsonConvert.DeserializeObject<ProductData>(File.ReadAllText(products));
            }
            else { productData.ProductsInit(); }
            return productData;
        }
        public void SerializeProducts(ProductData productData) 
        {
            File.WriteAllText(products, JsonConvert.SerializeObject(productData));
        }
    }
}
