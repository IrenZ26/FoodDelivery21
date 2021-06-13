using FoodDelivery21.Contracts;
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
        private readonly IProductData _productData;
        public ProductUI(IProductData productData)
        {
            _productData = productData;
        }
        public decimal UpdateProduct(int productId, decimal value, string action)
        {
            decimal result = 0;
            var productService = new ProductService(_productData);
            if (action == "dec")
            {
                var isEnough = productService.DecrementProducts(value, out value, productId);
                if (!isEnough)
                {
                    ByuerInterface buyerClient = new ByuerInterface();
                    buyerClient.ShowQuantErrMessage(value);
                }
                result = value;
            }
            if (action == "inc")
            {
                result = productService.IncrementProducts(value, productId);
            }
            return result;
        }

        public Product AddProductToOrder()
        {
            int id = GetProductId();
            var product = _productData.Products[id - 1];
            return product;
        }

        public int GetProductId()
        {
            var buyer = new ByuerInterface(_productData);
            var answer = buyer.ShowProducts();
            int result;
            int.TryParse(answer, out result);
            return result;
        }
    }
}
