using EF_Store.Domain;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Сontracts;
using System.Collections.Generic;

namespace StorePhoneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();       
        }

        [HttpPost("AddProducts")]
        public void AddProducts(Product product)
        {
            _productService.AddProduct(product);
        }

        [HttpDelete("DeleteProduct/{id?}")]
        public void DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}