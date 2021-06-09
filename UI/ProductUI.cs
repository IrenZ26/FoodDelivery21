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
<<<<<<< HEAD
                var isEnough = product.DecrementProducts(productData, value, out value, productId);
                if (!isEnough)
=======
                var f = product.DecrementProducts(productData, value, out value, productId);
                if (!f)
>>>>>>> regexValidation
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
<<<<<<< HEAD

        public Product AddProductToOrder(ProductData productData)
        {
            int id = GetProductId(productData);
            var product = productData.Products[id - 1];
            return product;
        }

=======
        public Product AddProductToOrder(ProductData productData)
        {
            int k = GetProductId(productData);
            var product = productData.Products[k - 1];
            return product;
        }
>>>>>>> regexValidation
        public int GetProductId(ProductData productData)
        {
            var buyer = new BuyerInterface();
            var answer = buyer.ShowProducts(productData);
<<<<<<< HEAD
            var validator = new Validator();
            var result = validator.CheckInt(answer);
=======
            int result;
            int.TryParse(answer, out result);
>>>>>>> regexValidation
            return result;
        }
    }
}
