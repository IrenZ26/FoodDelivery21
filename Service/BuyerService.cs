using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.UI
{
    public class BuyerService
    {
        public void CreateOrder()
        {
            var order = new OrderUI();
            order.CreateOrder();
            var logger = new Logger();
            var loggerMassage = "New order was successfully saved";
            logger.SaveIntoFile(loggerMassage);
        }
    }
}
