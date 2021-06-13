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
        Product CreateProduct(string companyName);

        void UpdateProduct(int productId, decimal value);

        void DeleteProduct(Product product);
    }
}
