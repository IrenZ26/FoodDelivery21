using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class SellerService
    {
        public Product CreateProduct(string companyName)
        {
            var product = new Product();
            var sellerClient = new SellerInterface();
            product = sellerClient.CreateProduct(companyName);
            return product;            
        }

        public void UpdateProduct(ProductData productData, int productId, decimal value)
        {
            var productUI = new ProductUI();
            productUI.UpdateProduct(productData, productId, value, "inc");
        }

        public void DeleteProduct(ProductData productData, Product product)
        {
            productData.Products.Remove(product);
        }
    }
}
