using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public decimal Price { get; set; }
        public IList<Delivery> Deliveries { get; set; }
        public Delivery(string method, decimal price)
        {
            Method = method;
            Price = price;
        }       
    }
}
