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
    public class DataInitializator
    {
        private const string deliveriesFilePath = "Delivery.json";
        private const string ordersFilePath = "Orders.json";
        private const string productsFilePath = "Products.json";
        private bool DataDeserialize<T>(ref T data)
        {
            var result = false;
            var path = GetPath<T>(data);
            if (File.Exists(path))
            {
                data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
                result = true;
            }
            return result;
        }

        private string GetPath<T>(T data)
        {
            var path = "";
            var type = data.GetType();
            if (type == typeof(DeliveryData)) { path = deliveriesFilePath; }
            if (type == typeof(OrderData)) { path = ordersFilePath; }
            if (type == typeof(ProductData)) { path = productsFilePath; }
            return path;
        }

        public DeliveryData GetDeliveryData()
        {
            var deliveryData = new DeliveryData();
            var IsExist = DataDeserialize<DeliveryData>(ref deliveryData);
            if (!IsExist)
            {
                deliveryData.DeliveryListInit();
            }
            return deliveryData;
        }

        public OrderData GetOrdersData()
        {
            var orderData = new OrderData();
            DataDeserialize<OrderData>(ref orderData);
            return orderData;
        }

        public ProductData GetProductsData()
        {
            var productData = new ProductData();
            var IsExist = DataDeserialize<ProductData>(ref productData);
            if (!IsExist)
            {
                productData.ProductsInit();
            }
            return productData;
        }

        public void SaveData<T>(T data)
        {
            var path = GetPath<T>(data);
            File.WriteAllText(path, JsonConvert.SerializeObject(data));
        }
    }
}
