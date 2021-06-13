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
        void DeleteProduct(Product product);
        bool IsExist(string companyName);
        void CreateProduct(Product product);
    }
}
