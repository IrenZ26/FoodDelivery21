using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Contracts
{
    public interface IBuyerService
    {
        bool IsExist(Buyer buyer);
        Buyer CreateBuyer(string name, string address, string telephone);
    }
}
