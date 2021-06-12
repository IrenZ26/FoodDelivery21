using FoodDelivery21.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Contracts
{
    public interface ISellerService
    {
        Product CreateProduct(string companyName, ProductData productData);

        void UpdateProduct(ProductData productData, int productId, decimal value);

        void DeleteProduct(ProductData productData, Product product);
    }
}
