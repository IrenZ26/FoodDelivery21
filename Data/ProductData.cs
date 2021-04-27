using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Data
{
    public class ProductData
    {
        public IList<Product> Products { get; set; }
        public ProductData()
        {
            Products = new List<Product>();
        }
        public void ProductsInit()
        {
            Product product = new Product(1,"Milk", "Milk factory", 12, 100, "white", 0.1m, 0.12m);
            Products.Add(product);
            Product product1 = new Product(2,"Bread", "Backery", 10, 100, "", 0.05m, 0);
            Products.Add(product1);
            Product product2 = new Product(3,"Eggs", "Newton`s farm", 15, 100, "chicken", 0, 0.1m);
            Products.Add(product2);
            Product product3 = new Product(4, "Cheese", "Milk factory", 20, 100, "white", 0.1m, 0.12m);
            Products.Add(product3);
        }
    }
}
