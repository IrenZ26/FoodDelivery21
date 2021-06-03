using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery21.Service
{
    public class ProductService
    {
        public bool DecrementProducts(ProductData productData, decimal value1, out decimal value, int productId)
        {
            bool result = false;
            decimal val = default;
            foreach (var item in productData.Products.Where(x => x.Id == productId))
            { 
                //if (item.Id == productId)
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
            }
            value = val;
            return result;
        }
        public decimal IncrementProducts(ProductData productData, decimal value, int productId)
        {
            decimal result = default;
            foreach (var item in productData.Products) 
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
