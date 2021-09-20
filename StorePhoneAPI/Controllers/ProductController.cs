using EF_Store.Domain;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Сontract;
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
        [ResponseCache(Duration = 120)]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();       
        }

        [HttpPost("AddProducts")]
        public IActionResult AddProducts(Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }

        [HttpDelete("DeleteProduct/{id?}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}