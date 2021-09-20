using EF_Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhone.Сontract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetProducts();

        void AddCategory(Category category);

        void DeleteCategory(int id);
    }
}