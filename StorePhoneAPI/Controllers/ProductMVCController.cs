using EF_Store.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Сontract;
using StorePhoneAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePhoneAPI.Controllers
{
    [ApiController]
    [Route("mvc/[controller]")]
    [ServiceFilter(typeof(ExceptionFilter))]
    public class ProductMVCController : Controller
    {
        private readonly IProductService _productService;

        public ProductMVCController(IProductService productService)
        {
            _productService = productService;
        }


        [ServiceFilter(typeof(RequestBodyActionFilter))]
        [HttpGet("index")]      
        public ActionResult Index()
        {
           var products = _productService.GetProducts();
            return View("Index",products);
        }


        [HttpGet("ProductDetails/{id}")]
        public ActionResult Details(int id)
        {
            var product = _productService.GetProduct(id);
            return View("ProductDetails", product);
        }

        [HttpGet("CreateProduct")]
        public ActionResult Create()
        {
            return View("CreateProduct");
        }

        [HttpPost("CreateProduct")]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateProduct");
            }
            _productService.AddProduct(product);

            return RedirectToAction("index");
        }

        [HttpGet("DeleteProduct/{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            
            return RedirectToAction("index");
        }
    }
}