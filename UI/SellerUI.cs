using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
    class SellerUI
    {
        public void CreateSeller(int id, string name, string address, string telephone)
        {
            var seller = new Seller(id, name, address, telephone);
        }
        public Product GetProduct(ProductData productData, int productId)
        {
            var product = new Product();
            foreach (var item in productData.Products)
            {
                if (item.Id == productId)
                {
                    product = item;
                }
            }
            return product;
        }
        public void StartWorking(string companyName)
        {
            var productData = new ProductData();
            productData.ProductsInit();
            var answer = Start(companyName);
            var sellerService = new SellerService();
            var logger = new Logger();
            var loggerMassage = "";
            if (answer == 1)
            {
                var productId = GetProductId(productData, companyName);
                var productValue = GetProductValue();
                loggerMassage = "The seller choose to change the quantity of " + productData.Products.ElementAt(productId-1).Name;
                logger.SaveIntoFile(loggerMassage);
                sellerService.UpdateProduct(productData, productId, productValue);

            }
            if (answer == 2)
            {
                var product = new Product();
                loggerMassage = "The seller choose to create the new product";
                logger.SaveIntoFile(loggerMassage);
                productData.Products.Add(product);
                product = sellerService.CreateProduct(companyName);
            }
            if (answer == 3)
            {
                var productId = GetProductId(productData, companyName);
                var product = new Product();
                product = GetProduct(productData, productId);
                loggerMassage = "The seller choose to delete the product";
                logger.SaveIntoFile(loggerMassage);
                sellerService.DeleteProduct(productData, product);
            }
        }
        public bool IsExist(string companyName)
        {
            var productData = new ProductData();
            productData.ProductsInit();
            bool result = false;
            foreach (var item in productData.Products)
            {
                if (item.CompanyName.Equals(companyName))
                {
                    result = true;
                }
            }
            return result;
        }
        public int GetResult(bool isExist)
        {
            var result = 2;
            if (isExist)
            {
                var sellerClient = new SellerInterface();
                var answer = sellerClient.ExistMassage();
                var validator = new Validator();
                result = validator.IntValidation(answer);
            }
            return result;
        }
        public int Start(string companyName)
        {
            var productData = new ProductData();
            productData.ProductsInit();
            bool isExist = IsExist(companyName);
            var logger = new Logger();
            var loggerMassage = "";
            if (isExist) {  loggerMassage = "Seller is already exist"; }
            else {  loggerMassage = "It`s a new seller"; }
            logger.SaveIntoFile(loggerMassage);
            var result = GetResult(isExist);
            return result;
        }
        public decimal GetProductValue()
        {
            var sellerClient = new SellerInterface();
            var answer = sellerClient.ProductValueMassage();
            var validator = new Validator();
            var value = validator.DecimalValidation(answer);
            return value;
        }

        public int GetProductId(ProductData productData, string companyName)
        {
            var validator = new Validator();
            var sellerClient = new SellerInterface();
            var answer = sellerClient.ShowProducts(productData, companyName);
            var result = validator.IntValidation(answer);
            return result;
        }
    }
}
