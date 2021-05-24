using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
    public class ProductUI
    {
        public decimal UpdateProduct(ProductData productData, int productId, decimal value, string action)
        {
            var product = new ProductService();
            decimal result = 0;
            if (action == "dec")
            {
                var f = product.DecrementProducts(productData, value, out value, productId);
                if (!f)
                {
                    BuyerInterface buyerClient = new BuyerInterface();
                    buyerClient.ShowQuantErrMassage(value);
                }
                result = value;
            }
            if (action == "inc")
            {
                result = product.IncrementProducts(productData, value, productId);
            }
            return result;
        }
        public Product AddProductToOrder(ProductData productData)
        {
            int k = GetProductId(productData);
            var product = productData.Products[k - 1];
            return product;
        }
        public int GetProductId(ProductData productData)
        {
            var buyer = new BuyerInterface();
            var answer = buyer.ShowProducts(productData);
            var validator = new Validator();
            var result = validator.IntValidation(answer);
            return result;
        }
    }
}
