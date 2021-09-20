using EF_Store.Domain;
using System.Collections.Generic;

namespace StorePhone.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

       Product GetProduct(int id);

        void AddProduct(string name, decimal price, string color, int memorySize);

        void AddProduct(Product product);

        void DeleteProduct(int id);
    }
}