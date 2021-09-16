using EF_Store.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Сontracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePhoneAPI.Controllers
{
    [ApiController]
    [Route("mvc/[controller]")]
    public class ProductMVCController : Controller
    {
        private readonly IProductService _productService;

        public ProductMVCController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("index")]      
        public ActionResult Index()
        {
           var products = _productService.GetProducts();
            return View("Index",products);
        }

        [HttpGet("Details/{id}")]
        public ActionResult Details(int id)
        {
            var product = _productService.GetProduct(id);
            return View("Details", product);
        }

        [HttpGet("create")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost("create")]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            _productService.AddProduct(product);

            return RedirectToAction("index");
        }

        [HttpGet("delete/{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            
            return RedirectToAction("index");
        }
    }
}