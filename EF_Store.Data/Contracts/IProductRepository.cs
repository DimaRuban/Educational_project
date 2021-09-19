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
        IEnumerable<Product> GetObjects();
        Product GetObject(int id);
        void CreateObject(Product item);
        void UpdateObject(Product item);
        void DeleteObject(int id);
    }
}
