using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class SellerService
    {
        public Product CreateProduct(string companyName,ProductData productData,Logger logger)
        {
            var product = new Product();
            var sellerClient = new SellerInterface();
            product = sellerClient.CreateProduct(companyName,productData);
            logger.SaveIntoFile("New product " + product.Name + " was successfully created");
            return product;            
        }

        public void UpdateProduct(ProductData productData, int productId, decimal value, Logger logger)
        {
            var productUI = new ProductUI();
            productUI.UpdateProduct(productData, productId, value, "inc",logger);
            logger.SaveIntoFile("The product`s quantity was successfully changed");
        }

        public void DeleteProduct(ProductData productData, Product product,Logger logger)
        {
            productData.Products.Remove(product);
            logger.SaveIntoFile("The product " + product.Name + " was successfully deleted");
        }

    }
}
