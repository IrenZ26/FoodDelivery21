using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodDelivery21.Service
{
    public delegate void ShowM(string message);
    public class CacheMaker
    {
        private static readonly object _ordersLock = new object();
        private static AutoResetEvent _orderAdded = new AutoResetEvent(false);
        public  ProductData cacheProductData = new ProductData();
        public  OrderData cacheOrderData = new OrderData();
        public  DeliveryData cacheDeliveryData = new DeliveryData();

        public void MakeTimer(ProductData productData, OrderData orderData, DeliveryData deliveryData)
        {
            var data = DateTime.Now;
            var data1 = DateTime.Now;
            var someFutureTime = data.AddMinutes(1);
            var future = someFutureTime.AddMilliseconds(1);
            lock (_ordersLock)
            {
                GetCache(productData, orderData, deliveryData);
                while (data1 < future)
                {
                    data1 = DateTime.Now;
                    if (data1 > someFutureTime)
                    {

                        GetCache(productData,orderData,deliveryData);
                        someFutureTime = data1.AddSeconds(1);
                        future = someFutureTime.AddMilliseconds(1);
                    }
                }
            }
            _orderAdded.Set();
        }

        public void GetCache(ProductData productData,OrderData orderData,DeliveryData deliveryData)
        {
            GetProductCache(productData);
            GetOrderCache(orderData);
            GetDeliveryCache(deliveryData);
            var message = "Cache has been updated";
            MakeDelegateWork(message);
        }
        public ProductData GetProductCache(ProductData productData)
        {
            foreach (var item in productData.Products)
            {
                if (!cacheProductData.Products.Contains(item))
                {
                    cacheProductData.Products.Add(item);
                }
            }
            return cacheProductData;
        }

        public OrderData GetOrderCache(OrderData orderData)
        {
            foreach (var item in orderData.Orders)
            {
                if (!cacheOrderData.Orders.Contains(item))
                {
                    cacheOrderData.Orders.Add(item);
                }                
            }
            return cacheOrderData;
        }

        public DeliveryData GetDeliveryCache(DeliveryData deliveryData)
        {
            foreach (var item in deliveryData.Deliveries)
            {
                if (!cacheDeliveryData.Deliveries.Contains(item))
                {
                    cacheDeliveryData.Deliveries.Add(item);
                }
            }
            return cacheDeliveryData;
        }
        private static void MakeDelegateWork(object x)
        {
            string mas = x.ToString();
            ShowM mes = ShowMessage;
            mes(mas);
        }

        private static void ShowMessage(string mes)
        {
            Console.WriteLine(mes);
        }

        public void StartCaching(ProductData productData, OrderData orderData, DeliveryData deliveryData)
        {
            var producer = new Thread(() =>
            {
                MakeTimer(productData, orderData, deliveryData);
                Thread.Sleep(300);
            });
            producer.IsBackground = true;
            producer.Name = "Cacher";
            var identificator = new Identification();
            producer.Start();
            bool f = identificator.IsContinue();
           if (!f)
            {
                producer.Abort();
            }
        }

    }
}
