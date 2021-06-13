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

        public decimal UpdateProduct(int productId, decimal value, string action)
        {
            decimal result = 0;
            if (action == "dec")
            {
                var isEnough = DecrementProducts( value, out value, productId);
                if (!isEnough)
                {
                    ByuerInterface buyerClient = new ByuerInterface();
                    buyerClient.ShowQuantErrMassage(value);
                }
                result = value;
            }
            if (action == "inc")
            {
                result = IncrementProducts(value, productId);
            }
            return result;
        }

        public Product AddProductToOrder()
        {
            int id = GetProductId();
            var product = _productData.Products[id - 1];
            return product;
        }

        public int GetProductId()
        {
            var buyer = new ByuerInterface(_productData);
            var answer = buyer.ShowProducts();
            int result;
            int.TryParse(answer, out result);
            return result;
        }
    }
}
