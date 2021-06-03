using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Contracts
{
    interface ILogger
    {
        void SaveIntoFile(string message);
    }
}
