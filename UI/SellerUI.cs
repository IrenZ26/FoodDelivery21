using FoodDelivery21.Contracts;
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
        private readonly IProductData _productData;
        public SellerUI(IProductData productData)
        {
            _productData = productData;
        }
        public Product GetProduct(int productId)
        {
            var product = new Product();
            foreach (var item in _productData.Products)
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
            var answer = Start(companyName);
            var sellerService = new SellerService(_productData);
            if (answer == 1)
            {
                var productId = GetProductId(companyName);
                var productValue = GetProductValue();
                sellerService.UpdateProduct(productId, productValue);

            }
            if (answer == 2)
            {
                var product = new Product();
                _productData.Products.Add(product);
                product = CreateProduct(companyName);
            }
            if (answer == 3)
            {
                var productId = GetProductId(companyName);
                var product = new Product();
                product = GetProduct(productId);
                sellerService.DeleteProduct(product);
            }
        }
        public Product CreateProduct(string companyName)
        {
            var product = new Product();
            var sellerClient = new SellerInterface(_productData);
            product = sellerClient.CreateProduct(companyName);
            return product;
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

        public int Start(string companyName)
        {
            bool isExist = IsExist(companyName);
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

        public int GetProductId(string companyName)
        {
            var sellerClient = new SellerInterface(_productData);
            var answer = sellerClient.ShowProducts(companyName);
            int result;
            int.TryParse(answer, out result);
            return result;
        }
    }
}
