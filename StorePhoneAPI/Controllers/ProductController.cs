using EF_Store.Domain;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Сontracts;
using System.Collections.Generic;

namespace StorePhoneAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();       
        }

        [HttpPost]
        public void AddProducts(Product product)
        {
            _productService.AddProduct(product);
        }

        [HttpDelete]
        public void DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}