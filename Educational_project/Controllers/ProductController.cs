using StorePhone.Models;
using StorePhone.Сontracts;
using System.Linq;

namespace StorePhone.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IDbContext _dbContext;

        public ProductController(IDbContext dbContext)
        {   
            _dbContext = dbContext;
        }

        public void AddNewProduct(string name, decimal price, string color, int memorySize)
        {
            int newProductId = _dbContext.Products.Max(x => x.Id) + 1;

            _dbContext.Products.Add(new Product(newProductId, name, price, color, memorySize));
        }
    }
}