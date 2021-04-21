using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DiscountPromoCode { get; set; }
        public void CreateOrder() { }
        public void UpdateOrder() { }
        public void DeleteOrder() { }
    }
}
