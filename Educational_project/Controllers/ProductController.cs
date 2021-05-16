using StorePhone.Models;
using StorePhone.Сontracts;
using System.Linq;

namespace StorePhone.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IDbContext _dbContext;
        private readonly Product _product;

        public ProductController(IDbContext dbContext, Product product)
        {   
            _dbContext = dbContext;
            _product = product;
        }

        public void AddNewProduct()
        {
            int newProductId = _dbContext.Products.Max(x => x.Id)+1;

            _dbContext.Products.Add(new Product(newProductId, _product.Name, _product.Price, _product.Color, _product.MemorySize));
        }
    }
}