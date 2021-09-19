using EF_Store.Domain;

namespace EF_Store.Data.Contracts
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IRepository<Order> Orders { get; }
        IRepository<User> Users { get; }
        IRepository<Category> Categories { get; }
        void Save();
        void Dispose();
    }
}