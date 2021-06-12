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
        public void StartWorking(string companyName, ProductData productData)
        {
            var answer = Start(companyName, productData);
            var sellerService = new SellerService();
            if (answer == 1)
            {
                var productId = GetProductId(productData, companyName);
                var productValue = GetProductValue();
                sellerService.UpdateProduct(productData, productId, productValue);

            }
            if (answer == 2)
            {
                var product = new Product();
                productData.Products.Add(product);
                product = sellerService.CreateProduct(companyName, productData);
            }
            if (answer == 3)
            {
                var productId = GetProductId(productData, companyName);
                var product = new Product();
                product = GetProduct(productData, productId);
                sellerService.DeleteProduct(productData, product);
            }
        }

        public bool IsExist(string companyName, ProductData productData)
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
            bool isExist = IsExist(companyName, productData);
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
