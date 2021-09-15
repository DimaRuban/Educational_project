using EF_Store.Domain;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Сontracts;
using System.Collections.Generic;


namespace StorePhoneAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
      
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryService.GetProducts();
        }     

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.AddCategory(category);
            return Ok();
        }
      
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}