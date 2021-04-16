using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Delivery
    {
        public  int Id;
        public string Method;
        public decimal Price;
        
        public void SetDeliveryPrice(string Method, decimal Price)
        {
        }
        public decimal GetDeliveryPrice(string Method)
        {
            decimal price = default;
            return price;
        }
    }
}
