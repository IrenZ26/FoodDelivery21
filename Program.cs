using System;

namespace FoodDelivery21
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller();
            seller.CreateProduct();
            Buyer buyer = new Buyer();
            buyer.CreateOrder();
        }
    }
}
