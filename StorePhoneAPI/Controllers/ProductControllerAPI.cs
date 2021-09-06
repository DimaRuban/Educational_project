using EF_Store.Data;
using EF_Store.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StorePhone.Controllers;
using StorePhone.Data;
using StorePhone.Logging;
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
            var productController = new ProductController(new UnitOfWork(new DataContext()));
            return productController.GetProducts();       
        }
    }
}