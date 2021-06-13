using FoodDelivery21.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Service
{
    public class BuyerService:IBuyerService
    {
        private readonly IOrderData _orderData;
        public BuyerService(IOrderData orderData)
        {
            _orderData = orderData;
        }
        public Buyer CreateBuyer(string name, string address, string telephone)
        {
            var buyer = new Buyer(name, address, telephone);
            return buyer;
        }
        public bool IsExist(Buyer buyer)
        {
            var result = false;

            foreach (var item in _orderData.Orders)
            {
                if ((item.Buyer.Name == buyer.Name) && (item.Buyer.Address == buyer.Address) && (item.Buyer.Telephone == buyer.Telephone)) { result = true; }
            }
            return result;
        }
    }
}
