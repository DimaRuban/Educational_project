using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StorePhone.Controllers;
using StorePhone.Data;
using StorePhone.Logging;
using StorePhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePhoneAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductControllerAPI : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var productController = new ProductController(new DbContext(),new Logger());

            return productController.GetProducts();       
        }
    }
}