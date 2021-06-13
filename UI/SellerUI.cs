using FoodDelivery21.Contracts;
using FoodDelivery21.Data;
using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.UI
{
    public class SellerUI
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ISellerService _sellerService;
        public SellerUI(IProductService productService,ISellerService sellerService,IOrderService orderService, IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
            _orderService = orderService;
            _productService = productService;
            _sellerService = sellerService;
        }
      
        public void StartWorking(string companyName)
        {
            var answer = Start(companyName);
            if (answer == 1)
            {
                var productId = GetProductId(companyName);
                var productValue = GetProductValue();
                var productUI = new ProductUI(_orderService,_productService,_deliveryService);
                productUI.UpdateProduct(productId, productValue, "inc");

            }
            if (answer == 2)
            {
                var product = new Product();
                product = CreateProduct(companyName);
                _sellerService.CreateProduct(product);
            }
            if (answer == 3)
            {
                var productId = GetProductId(companyName);
                var product = new Product();
                product = _productService.GetProductByID(productId);
                _sellerService.DeleteProduct(product);
            }
            _productService.ShowProducts();
        }

        public Product CreateProduct(string companyName)
        {
            var product = new Product();
            var sellerClient = new SellerInterface(_orderService,_productService);
            product = sellerClient.CreateProduct(companyName);
            return product;
        }

        public int GetResult(bool isExist)
        {
            var result = 2;
            if (isExist)
            {
                var sellerClient = new SellerInterface();
                var answer = sellerClient.ExistMessage();
                int.TryParse(answer, out result);
            }
            return result;
        }

        public int Start(string companyName)
        {
            bool isExist = _sellerService.IsExist(companyName);
            var result = GetResult(isExist);
            return result;
        }

        public decimal GetProductValue()
        {
            var sellerClient = new SellerInterface();
            var answer = sellerClient.ProductValueMessage();
            decimal result;
            decimal.TryParse(answer, out result);
            return result;
        }

        public int GetProductId(string companyName)
        {
            var sellerClient = new SellerInterface(_orderService,_productService);
            var answer = sellerClient.ShowProducts(companyName);
            int result;
            int.TryParse(answer, out result);
            return result;
        }
    }
}
