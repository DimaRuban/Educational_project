using EF_Store.Data.Contracts;
using EF_Store.Domain;
using StorePhone.Сontracts;
using System.Collections.Generic;

namespace StorePhone.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _dbContext;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public void AddCategory(Category category)
        {
            _dbContext.Categories.CreateObject(category);
            _dbContext.Save();
        }

        public void DeleteCategory(int id)
        {
            _dbContext.Categories.DeleteObject(id);
            _dbContext.Save();
        }

        public IEnumerable<Category> GetProducts()
        {
            return _dbContext.Categories.GetObjects();
        }
    }
}