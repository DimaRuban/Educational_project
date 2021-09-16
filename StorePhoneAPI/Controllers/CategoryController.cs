using EF_Store.Domain;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Сontracts;
using System.Collections.Generic;


namespace StorePhoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("Get")]
        public IEnumerable<Category> Get()
        {
            return _categoryService.GetProducts();
        }     

        [HttpPost("AddCategory")]
        public void AddCategory(Category category)
        {
            _categoryService.AddCategory(category);
        }

        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}