using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Contracts
{
    public interface IOrderData
    {
        IList<Order> Orders { get; set; }
    }
}
