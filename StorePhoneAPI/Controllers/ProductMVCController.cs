using EF_Store.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Сontracts;
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

        // GET: ProductMVCController
        [HttpGet("index")]
        [ServiceFilter(typeof(RequestBodyActionFilter))]
        public ActionResult Index()
        {
           var products = _productService.GetProducts();
            return View("Index",products);
        }

        // GET: ProductMVCController/Details/id
        [HttpGet("Details/{id}")]
        public ActionResult Details(int id)
        {
            var product = _productService.GetProduct(id);
            return View("Details", product);
        }

        // GET: ProductMVCController/Create
        [HttpGet("create")]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: ProductMVCController/Create
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

        // GET: ProductMVCController/Delete/id
        [HttpGet("delete/{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            
            return RedirectToAction("index");
        }
    }
}