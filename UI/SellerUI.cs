using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public class SellerUI
=======
     public class SellerUI
>>>>>>> regexValidation
=======
    public class SellerUI
>>>>>>> logger
=======
    public class SellerUI
>>>>>>> jsonSerialization
    {
        public void CreateSeller(int id, string name, string address, string telephone)
        {
            var seller = new Seller(id, name, address, telephone);
        }
<<<<<<< HEAD

=======
>>>>>>> regexValidation
        public Product GetProduct(ProductData productData, int productId)
        {
            var product = new Product();
            foreach (var item in productData.Products)
            {
                if (item.Id == productId)
                {
                    product = item;
                }
            }
            return product;
        }
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> regexValidation
        public void StartWorking(string companyName)
=======
        public void StartWorking(string companyName, ProductData productData,OrderData orderData)
>>>>>>> jsonSerialization
        {
            var answer = Start(companyName, productData);
            var sellerService = new SellerService();
            var logger = new Logger();
            var loggerMassage = "";
            if (answer == 1)
            {
                var productId = GetProductId(productData, companyName);
                var productValue = GetProductValue();
                logger.SaveIntoFile("The seller choose to change the quantity of " + productData.Products.ElementAt(productId - 1).Name);
                sellerService.UpdateProduct(productData, productId, productValue);

            }
            if (answer == 2)
            {
                var product = new Product();
<<<<<<< HEAD
                logger.SaveIntoFile("The seller choose to create the new product");
=======
                product = sellerService.CreateProduct(companyName,productData);
>>>>>>> jsonSerialization
                productData.Products.Add(product);
                product = sellerService.CreateProduct(companyName);
            }
            if (answer == 3)
            {
                var productId = GetProductId(productData, companyName);
                var product = new Product();
                product = GetProduct(productData, productId);
                logger.SaveIntoFile("The seller choose to delete the product");
                sellerService.DeleteProduct(productData, product);
            }
            if (answer == 4)
            {
                sellerService.UpdateStatus(orderData, companyName);
            }
        }
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> regexValidation
        public bool IsExist(string companyName)
=======
        public bool IsExist(ProductData productData, string companyName)
>>>>>>> jsonSerialization
        {
            bool result = false;
            foreach (var item in productData.Products)
            {
                if (item.CompanyName.Equals(companyName))
                {
                    result = true;
                }
            }
            return result;
        }
<<<<<<< HEAD

=======
>>>>>>> regexValidation
        public int GetResult(bool isExist)
        {
            var result = 2;
            if (isExist)
            {
                var sellerClient = new SellerInterface();
                var answer = sellerClient.ExistMassage();
<<<<<<< HEAD
                var validator = new Validator();
                result = validator.CheckInt(answer);
            }
            return result;
        }

=======
                int.TryParse(answer, out result);
            }
            return result;
        }
<<<<<<< HEAD
>>>>>>> regexValidation
        public int Start(string companyName)
        {
            var productData = new ProductData();
            productData.ProductsInit();
            bool isExist = IsExist(companyName);
            var logger = new Logger();
            if (isExist) 
            {
                logger.SaveIntoFile("Seller is already exist");
            }
            else
            {
                logger.SaveIntoFile("It`s a new seller");
            }
=======
        public int Start(string companyName, ProductData productData)
        {
            bool isExist = IsExist(productData,companyName);
>>>>>>> jsonSerialization
            var result = GetResult(isExist);
            return result;
        }
<<<<<<< HEAD

=======
>>>>>>> regexValidation
        public decimal GetProductValue()
        {
            var sellerClient = new SellerInterface();
            var answer = sellerClient.ProductValueMassage();
<<<<<<< HEAD
            var validator = new Validator();
            var value = validator.CheckDecimal(answer);
            return value;
=======
            decimal result;
            decimal.TryParse(answer, out result);
            return result;
>>>>>>> regexValidation
        }

        public int GetProductId(ProductData productData, string companyName)
        {
<<<<<<< HEAD
            var validator = new Validator();
            var sellerClient = new SellerInterface();
            var answer = sellerClient.ShowProducts(productData, companyName);
            var result = validator.CheckInt(answer);
=======
            var sellerClient = new SellerInterface();
            var answer = sellerClient.ShowProducts(productData, companyName);
            int result;
            int.TryParse(answer, out result);
>>>>>>> regexValidation
            return result;
        }
    }
}
