using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
    public class SellerUI
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

        public void StartWorking(string companyName, ProductData productData,OrderData orderData)
        {
            var answer = Start(companyName, productData);
            var sellerService = new SellerService();
            var logger = new Logger();
            if (answer == 1)
            {
                var productId = GetProductId(productData, companyName);
                var productValue = GetProductValue();
                logger.SaveIntoFile("The seller choose to change the quantity of " + productData.Products.ElementAt(productId - 1).Name);
                sellerService.UpdateProduct(productData, productId, productValue);

            }
            if (answer == 2)
            {
                var product = new Product();
                logger.SaveIntoFile("The seller choose to create the new product");
                product = sellerService.CreateProduct(companyName,productData);
                productData.Products.Add(product);
            }
            if (answer == 3)
            {
                var productId = GetProductId(productData, companyName);
                var product = new Product();
                product = GetProduct(productData, productId);
                logger.SaveIntoFile("The seller choose to delete the product");
                sellerService.DeleteProduct(productData, product);
            }
            if (answer == 4)
            {
                sellerService.UpdateStatus(orderData, companyName);
            }
        }

        public bool IsExist(ProductData productData, string companyName)
        {
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
                int.TryParse(answer, out result);
            }
            return result;
        }

        public int Start(string companyName, ProductData productData)
        {
            bool isExist = IsExist(productData,companyName);
            var logger = new Logger();
            if (isExist) 
            {
                logger.SaveIntoFile("Seller is already exist");
            }
            else
            {
                logger.SaveIntoFile("It`s a new seller");
            }
            var result = GetResult(isExist);
            return result;
        }

        public decimal GetProductValue()
        {
            var sellerClient = new SellerInterface();
            var answer = sellerClient.ProductValueMassage();
            decimal result;
            decimal.TryParse(answer, out result);
            return result;
        }

        public int GetProductId(ProductData productData, string companyName)
        {
            var sellerClient = new SellerInterface();
            var answer = sellerClient.ShowProducts(productData, companyName);
            int result;
            int.TryParse(answer, out result);
            return result;
        }
    }
}
