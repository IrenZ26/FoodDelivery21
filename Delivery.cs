using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Delivery
    {
        public  int Id { get; set; }
        public string Method { get; set; }
        public decimal Price { get; set; }
        public IList<Delivery> Deliveries { get; set; }
        public Delivery(string method,decimal price) 
        {
            Method = method;
            Price = price;
        }
        public Delivery()
        {
            Deliveries = new List<Delivery>();
        }
        private void DeliveryListInit() 
        {
            Delivery delivery = new Delivery("deliver by courier",15);
            Deliveries.Add(delivery);
            Delivery delivery1 = new Delivery("deliver to the post office", 10);
            Deliveries.Add(delivery1);
        }
        public decimal GetDelivery() 
        {
            DeliveryListInit();
            decimal price = default;
            foreach(var item in Deliveries)
            {
                Console.WriteLine(item.Method+" costs "+item.Price+"$");
            }
            Console.WriteLine("Enter delivery method`s id");
            string ans = Console.ReadLine();
            int k = 1;
            try
                {
                k = int.Parse(ans);
            }
                catch (FormatException)
            {

                Console.WriteLine("Input Error");
            }
            price = GetDeliveryPrice(Deliveries[k-1].Method);
            return price;
        }
        public void SetDeliveryPrice(string Method, decimal Price)
        {
            Delivery delivery = new Delivery(Method, Price);
            Deliveries.Add(delivery);
        }
        public decimal GetDeliveryPrice(string Method)
        {
            DeliveryListInit();
            decimal price = default;
            foreach (var item in Deliveries)
            {
                if (item.Method == Method) { price = item.Price; }
            }
            return price;
        }
    }
}
