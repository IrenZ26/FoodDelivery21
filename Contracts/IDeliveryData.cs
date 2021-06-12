using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Contracts
{
    public interface IDeliveryData
    {
        public IList<Delivery> Deliveries { get; set; }

        void DeliveryListInit();
    }
}
