using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class SellerService
    {
        public void CreateSeller(int id, string name,string address) 
        {
            var seller = new Seller(id, name, address);
        }
        public Product CreateProduct(string companyName)
        {
            var product = new Product();
            var sellerClient = new SellerClient();
            product = sellerClient.CreateProduct(companyName);
            return product;            
        }
        public void UpdateProduct(ProductData productData, int productId, decimal value)
        {
            var productService = new ProductService();
            productService.UpdateProduct(productData, productId, value, "inc");
        }
        public void DeleteProduct(ProductData productData, int productId)
        {
            var product = new Product();
            foreach (var item in productData.Products)
            {
                if (item.Id == productId) 
                {
                    product = item;
                }
            }
            productData.Products.Remove(product);
        }

    }
}
