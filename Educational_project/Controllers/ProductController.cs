using StorePhone.Models;
using StorePhone.Сontracts;

namespace StorePhone.Controllers
{
    public class ProductController : IProductController
    {
        public string NewProductName { get; set; }
        public decimal NewProductPrice { get; set; }
        public string NewProductColor { get; set; }
        public int NewProductMemorySize { get; set; }

        private readonly IDbContext _dbContext;

        public ProductController(IDbContext dbContext)
        {   
            _dbContext = dbContext;
        }

        public void AddNewProduct()
        {
             int newProductId = _dbContext.Products.Count + 1;
                
            _dbContext.Products.Add(new Product(newProductId, NewProductName, NewProductPrice, new Color { Name = NewProductColor }, new MemorySize { Size = NewProductMemorySize }));
        }
    }
}