using FoodDelivery21.Data;
using FoodDelivery21.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    public class ProductService
    {

        public decimal UpdateProduct(ProductData productData,int productId,decimal value,string action) 
        {
            decimal result=0;
            foreach (var item in productData.Products) 
            {
                if(action=="dec")
                { 
                    if (item.Id==productId)
                    {
                        if (item.AvailableValue >= value)
                        {
                            item.AvailableValue = item.AvailableValue - value;
                            result = value;
                        }
                        else
                        {
                            BuyerClient buyerClient = new BuyerClient();
                            buyerClient.ShowQuantErrMassage(item.AvailableValue);
                            result = item.AvailableValue;
                            item.AvailableValue = 0;
                        }
                    }
                } 
                else if (action == "inc")
                {
                    if (item.Id == productId)
                    {
                        item.AvailableValue = item.AvailableValue + value;
                        result = value;
                    }
                }
            }
            return result;
        }
        public void DeleteProduct() { }
        public Product AddProductToOrder(ProductData productData)
        {
            var buyerClient = new BuyerClient();
            int k = buyerClient.GetProductId(productData);
            var product = productData.Products[k - 1];
            return product;
        }
    }
}
