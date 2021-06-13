using FoodDelivery21.Contracts;
using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    public class Identification : IUserInterface
    {
        private readonly ISellerService _sellerService;
        private readonly IDeliveryService _deliveryService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IBuyerService _buyerService;
        public Identification(IOrderService orderService, IProductService productService, IDeliveryService deliveryService,ISellerService sellerService,IBuyerService buyerService)
        {
            _deliveryService = deliveryService;
            _orderService = orderService;
            _productService = productService;
            _sellerService = sellerService;
            _buyerService = buyerService;
        }
        public void Start()
        {
            Console.WriteLine("Welcome to the food delivery service. Please, identify yourself");
            Console.WriteLine("Enter your personal or company name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter your address");
            var address = Console.ReadLine();
            Console.WriteLine("Enter your telephone number");
            var telephone = Console.ReadLine();
            var roleValid = false;
            while (!roleValid)
            {
                Console.WriteLine("Enter 1 if you are a buyer or 2 if you are a seller");
                var answer = Console.ReadLine();
                int role;
                int.TryParse(answer, out role);
                if (role == 1)
                {
                    roleValid = true;
                    Buyer buyer = _buyerService.CreateBuyer(name, address, telephone);
                    var order = new OrderUI(_orderService, _productService, _deliveryService,_buyerService);
                    order.CreateOrder(buyer);
                }
                else if (role == 2)
                {
                    roleValid = true;
                    var seller = new SellerUI(_productService,_sellerService,_orderService,_deliveryService);
                    seller.StartWorking(name);
                }
                else
                {
                    Console.WriteLine("Your role isn`t valid. Try again");
                }
            }
            Console.WriteLine("Thank you for using our Delivery Service");
        }
    }
}
