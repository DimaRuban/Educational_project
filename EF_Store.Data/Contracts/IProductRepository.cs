using EF_Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Store.Data.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product Get(int id);
        void Create(Product item);
        void Update(Product item);
        void Delete(int id);
    }
}
