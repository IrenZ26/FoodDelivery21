using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductValue { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal PrivateDiscount { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal TotalPrice { get; set; }
        public IList<Order> Orders { get; set; }
        public Order()
        {
            Orders = new List<Order>();
        }
        public Order(string productName, int productValue, decimal productPrice, decimal privateDiscount, decimal productDiscount, decimal totalPrice) 
        {
            ProductName = productName;
            ProductValue = productValue;
            ProductPrice = productPrice;
            PrivateDiscount = privateDiscount;
            ProductDiscount = productDiscount;
            TotalPrice = totalPrice;
        }
        public void CreateOrder() 
        {
            bool f = true;
            while (f)
            {
                f = false;
                Orders.Add(AddOrderItem());
                Console.WriteLine("If you want to continue shopping enter 'Y/y'.\nIf your order is complete, enter any other key.");
                string ans = Console.ReadLine();
                if (ans == "Y") { f = true; }
                else if (ans == "y") { f = true; }
            }
            decimal totalPrice = 0;
            Delivery delivery = new Delivery();
            totalPrice += delivery.GetDelivery();
            Console.WriteLine("Your order: ");
            foreach(var item in Orders) 
            {
                decimal discount = (item.PrivateDiscount + item.ProductDiscount)*100;
                Console.WriteLine(item.ProductName+" "+item.ProductValue+" items, costs "+item.ProductPrice+"$ for one item.\nDiscount = "+discount+"%. Total price = "+item.TotalPrice+"$");
                totalPrice += item.TotalPrice;
            }
            Console.WriteLine("Total price of the whole order with delivery = "+totalPrice);
        }
        public Order AddOrderItem() 
        {
            Product product = new Product();
            product = product.AddProductToOrder();
            Console.WriteLine("Enter how many items you want to buy");
            string ans = Console.ReadLine();
            decimal totalPrice = product.Price;
            int value = 1;
            try
            {
                value = int.Parse(ans);
            }
            catch (FormatException)
            {

                Console.WriteLine("Input Error");
            }
            totalPrice *= value;
            Console.WriteLine("Enter your promocode. If you don`t have any promo code, just press 'Enter'");
            string promo = Console.ReadLine();
            decimal discount = product.ProductDiscount;
            if (product.DiscountPromoCode.Equals(promo)) 
            { 
                PrivateDiscount = product.PersonalDiscount;
                discount += product.PersonalDiscount;
            }
            else { PrivateDiscount = 0; }
            totalPrice = GetDiscount(totalPrice,discount);
            Order order = new Order(product.Name,value,product.Price,PrivateDiscount,product.ProductDiscount,totalPrice);
            return order;
        }
        private decimal GetDiscount(decimal price, decimal discount)
        {
            decimal result = Math.Round(price - (price * discount), 2);
            return result;
        }
        public void UpdateOrder() { }
        public void DeleteOrder() { }
    }
}
