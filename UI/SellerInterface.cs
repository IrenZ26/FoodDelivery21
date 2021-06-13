using FoodDelivery21.Contracts;
using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    public class SellerInterface
    {
        private readonly IOrderData _orderData;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public SellerInterface(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public SellerInterface(IOrderData orderData) 
        {
            _orderData = orderData;
        }
        public SellerInterface() { }
        public Product CreateProduct(string companyName)
        {
            Console.WriteLine("Enter product id");
            var answer = Console.ReadLine();
            int id;
            int.TryParse(answer, out id);
            Console.WriteLine("Enter product name");
            var productName = Console.ReadLine();
            Console.WriteLine("Enter company price");
            answer = Console.ReadLine().Replace(".", ",");            
            decimal price;
            decimal.TryParse(answer, out price);
            Console.WriteLine("Enter quantity of products");
            answer = Console.ReadLine().Replace(".", ",");
            decimal availableValue;
            decimal.TryParse(answer, out availableValue);
            Console.WriteLine("Enter discount promo code");
            var promoCode = Console.ReadLine();
            Console.WriteLine("Enter product discount");
            answer = Console.ReadLine().Replace(".", ",");
            decimal productDiscount;
            decimal.TryParse(answer, out productDiscount);
            Console.WriteLine("Enter personal discount");
            answer = Console.ReadLine().Replace(".", ",");
            decimal personalDiscount;
            decimal.TryParse(answer, out personalDiscount);
            var product = new Product(id,productName, companyName, price, availableValue, promoCode, productDiscount, personalDiscount);
            Console.WriteLine("The product was succsesfully create:");
            Console.WriteLine("id:"+product.Id+" Name: " + product.Name + " Company: " + product.CompanyName + " Price: " + product.Price + "$ Avalible: " + product.AvailableValue + "items Promo code: " + product.DiscountPromoCode + " Product discount: " + product.ProductDiscount + " Personal discount: " + product.PersonalDiscount);
            return product;
        }

        public string ExistMessage()
        {
            Console.WriteLine("If you want to update your products enter 1\n" +
                "If you want to add new products enter 2\n" +
                "If you want to delete your products enter 3");
            var result = Console.ReadLine();
            return result;
        }

        public string ProductValueMessage()
        {
            Console.WriteLine("Enter how many items do you want to add");
            var result = Console.ReadLine();
            return result;
        }

        public string ShowProducts(string companyName)
        {
            _productService.ShowProducts(companyName);
            var result = Console.ReadLine();
            return result;
        }

        public string ShowOrdersStatus(string companyName)
        {
            foreach (var item in _orderData.Orders)
            {
                if (item.Product.CompanyName == companyName)
                {
                    Console.WriteLine(item.Id + " product: " + item.Product.Name);
                }
            }
            Console.WriteLine("Enter the order`s id which status you want to change");
            string result = Console.ReadLine();
            return result;
        }

        public string ShowStatusMessage()
        {
            Console.WriteLine("What is a new status of selected order?\n" +
               "Enter 1 if the status is Cancelled\n" +
               "Enter 2 if the status is Packed\n" +
               "Enter 3 if the status is Delivered\n" +
               "Enter any other number if you dont want to change the status");
            var result = Console.ReadLine();
            return result;
        }
    }
}
