using StorePhone.Models;
using StorePhone.Сontracts;

namespace StorePhone.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IDbContext _dbContext;
        private readonly IProductUi _productUi;

        public ProductController(IDbContext dbContext, IProductUi productUi)
        {   
            _dbContext = dbContext;
            _productUi = productUi;
        }

        public void AddNewProduct()
        {
             _productUi.AddNewProductUi();
             int newProductId = _dbContext.Products.Count + 1;
             string newProductName =_productUi.NewProductName;             
             decimal newProductPrice =_productUi.NewProductPrice;
             string newProductColor =_productUi.NewProductColor;
             int newProductMemorySize =_productUi.NewProductMemorySize;
                
            _dbContext.Products.Add(new Product(newProductId, newProductName, newProductPrice, new Color { Name = newProductColor }, new MemorySize { Size = newProductMemorySize }));
            _productUi.InformAboutSuccess();
        }
        public void PrintProduct()
        {
            _dbContext.InitData();
            _productUi.PrintProductUi();  
        }
    }
}
