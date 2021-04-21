using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public void CreateProduct() 
        {
            Product product = new Product();
            product = product.CreateProduct();
            Console.WriteLine("Name "+product.Name+" Company "+product.CompanyName+" Price "+product.Price+" Promo code "+product.DiscountPromoCode+" Product discount "+product.ProductDiscount+" Personal discount "+product.PersonalDiscount);
        }
        public void UpdateProduct()
        {
        }
        public void DeleteProduct()
        {
        }

    }
}
    
