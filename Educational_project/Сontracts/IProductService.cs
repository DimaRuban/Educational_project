using EF_Store.Domain;
using System.Collections.Generic;

namespace StorePhone.Сontracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        void AddProduct(string name, decimal price, string color, int memorySize);

        void AddProduct(Product product);

        void DeleteProduct(int id);
    }
}