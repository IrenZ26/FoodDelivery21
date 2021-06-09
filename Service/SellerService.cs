using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class SellerService
    {
        public Product CreateProduct(string companyName,ProductData productData)
        {
            var product = new Product();
            var sellerClient = new SellerInterface();
<<<<<<< HEAD
            product = sellerClient.CreateProduct(companyName);
            var logger = new Logger();
            logger.SaveIntoFile("New product " + product.Name + " was successfully created");
=======
            product = sellerClient.CreateProduct(companyName,productData);
>>>>>>> jsonSerialization
            return product;            
        }

        public void UpdateProduct(ProductData productData, int productId, decimal value)
        {
            var productUI = new ProductUI();
            productUI.UpdateProduct(productData, productId, value, "inc");
            var logger = new Logger();
            logger.SaveIntoFile("The product`s quantity was successfully changed");
        }
<<<<<<< HEAD

=======
>>>>>>> regexValidation
        public void DeleteProduct(ProductData productData, Product product)
        {
            productData.Products.Remove(product);
            var logger = new Logger();
            logger.SaveIntoFile("The product " + product.Name + " was successfully deleted");
        }
        public void UpdateStatus(OrderData orderData, string companyName)
        {
            var orderUI = new OrderUI();
            var id = orderUI.GetOrderID(orderData, companyName);
            var status = orderUI.GetNewStatus();
            orderUI.SetNewStatus(orderData, id, status);
        }

    }
}
