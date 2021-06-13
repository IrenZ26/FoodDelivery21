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

        public Product CreateProduct(string companyName)
        {
            var product = new Product();
            var sellerClient = new SellerInterface(_productData);
            product = sellerClient.CreateProduct(companyName);
            return product;            
        }

        public void UpdateProduct(int productId, decimal value)
        {
            var productUI = new ProductService(_productData);
            productUI.UpdateProduct(productId, value, "inc");
        }

        public void DeleteProduct(Product product)
        {
            _productData.Products.Remove(product);
        }

    }
}
