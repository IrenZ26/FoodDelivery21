using FoodDelivery21.Contracts;
using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class SellerService: ISellerService
    {
        private readonly IProductData _productData;
        public SellerService(IProductData productData)
        {
            _productData = productData;
        }

        public bool IsExist(string companyName)
        {
            bool result = false;
            foreach (var item in _productData.Products)
            {
                if (item.CompanyName.Equals(companyName))
                {
                    result = true;
                }
            }
            return result;
        }

        public void DeleteProduct(Product product)
        {
            _productData.Products.Remove(product);
        }

        public void CreateProduct(Product product)
        {
            _productData.Products.Add(product);
        }
    }
}
