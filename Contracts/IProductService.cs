using FoodDelivery21.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Contracts
{
    public interface IProductService
    {       
        bool DecrementProducts(decimal value1, out decimal value, int productId);

        decimal IncrementProducts(decimal value, int productId);
    }
}
