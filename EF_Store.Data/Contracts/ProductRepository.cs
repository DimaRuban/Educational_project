using EF_Store.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Store.Data.Contracts
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dbContext;

        public ProductRepository(DataContext DbContext)
        {
            _dbContext = DbContext;
        }
        public void Create(Product item)
        {
            _dbContext.Add(item);
        }

        public void Delete(int id)
        {
            var objectToDelete = _dbContext.Set<Product>().Find(id);
            if (objectToDelete != null)
            {
                _dbContext.Set<Product>().Remove(objectToDelete);
            }
        }

        public Product Get(int id)
        {

            return _dbContext.Products.Include(x => x.Category).Include(x=>x.Provider).Include(x => x.Color).Include(x=>x.MemorySize).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> Get()
        {
            return _dbContext.Products.Include(x => x.Category).Include(x => x.Provider).Include(x => x.Color).Include(x => x.MemorySize);
        }

        public void Update(Product item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
