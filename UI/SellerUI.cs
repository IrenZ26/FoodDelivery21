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
        public void StartWorking(string companyName, ProductData cacheProductData, ProductData productData, OrderData orderData)
        {
            var answer = Start(companyName, cacheProductData);
            var sellerService = new SellerService();
            if (answer == 1)
            {
                var productId = GetProductId(cacheProductData, companyName);
                var productValue = GetProductValue();
                sellerService.UpdateProduct(productData, productId, productValue);
            }
            if (answer == 2)
            {
                var product = new Product();
                product = sellerService.CreateProduct(companyName,productData);
                productData.Products.Add(product);
            }
            if (answer == 3)
            {
                var productId = GetProductId(cacheProductData, companyName);
                var product = new Product();
                product = GetProduct(cacheProductData, productId);
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
                var validator = new Validator();
                result = validator.IntValidation(answer);
            }
            return result;
        }
        public int Start(string companyName, ProductData productData)
        {
            bool isExist = IsExist(productData,companyName);
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
