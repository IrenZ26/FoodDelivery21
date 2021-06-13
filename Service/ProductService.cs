using FoodDelivery21.Contracts;
using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery21.Service
{
    public class ProductService: IProductService
    {
        private readonly IProductData _productData;
        public ProductService(IProductData productData)
        {
            _productData = productData;
        }
        public bool DecrementProducts(decimal value1, out decimal value, int productId)
        {
            bool result = false;
            decimal val = default;
            foreach (var item in _productData.Products.Where(x => x.Id == productId))
            { 
                    if (item.AvailableValue >= value1)
                    {
                        item.AvailableValue = item.AvailableValue - value1;
                        val = value1;
                        result = true;
                    }
                    else
                    {
                        val = item.AvailableValue;
                        item.AvailableValue = 0;
                        result = false;
                    }
            }
            value = val;
            return result;
        }

        public void ShowProducts()
        {
            foreach (var item in _productData.Products)
            {
                Console.WriteLine(item.Name + " from " + item.CompanyName + " costs " + item.Price + "$." + "Available: " + item.AvailableValue + " items");
            }
        }
        public void ShowProducts(string companyName)
        {
            Console.WriteLine("Chose product and enter it`s id:");
            foreach (var item in _productData.Products)
            {
                if (item.CompanyName.Equals(companyName))
                {
                    Console.WriteLine(item.Id + " " + item.Name);
                }
            }
        }
        public Product GetProductByID(int productId)
        {
            var product = new Product();
            foreach (var item in _productData.Products)
            {
                if (item.Id == productId)
                {
                    product = item;
                }
            }
            return product;
        }
        public Product GetProduct(int id)
        {
            var product = _productData.Products[id];
            return product;
        }
        public decimal IncrementProducts(decimal value, int productId)
        {
            decimal result = default;
            foreach (var item in _productData.Products) 
            { 
                if ((item.Id == productId)&&(item.AvailableValue >= value))
                {
                        item.AvailableValue = item.AvailableValue + value;
                        result = item.AvailableValue;
                }
            }
            return result;
        }
    }
}
