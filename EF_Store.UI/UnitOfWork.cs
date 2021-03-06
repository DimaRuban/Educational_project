using EF_Store.Data;
using EF_Store.Domain;
using System;

namespace EF_Store.UI
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;

        private IRepository<Product> products;
        private IRepository<Category> categories;
        private IRepository<Color> colors;
        private IRepository<MemorySize> memorySizes;
        private IRepository<Provider> providers;
        private IRepository<Order> orders;
        private IRepository<Status> statuses;
        private IRepository<User> users;
        private IRepository<Role> roles;

        public UnitOfWork(DataContext context)
        {
            _dbContext = context;
        }

        public IRepository<Product> Products
        {
            get
            {
                return products ??
                    (products = new Repository<Product>(_dbContext));
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return categories ??
                    (categories = new Repository<Category>(_dbContext));
            }
        }
        public IRepository<Color> Colors
        {
            get
            {
                return colors ??
                    (colors = new Repository<Color>(_dbContext));
            }
        }
        public IRepository<MemorySize> MemorySizes
        {
            get
            {
                return memorySizes ??
                    (memorySizes = new Repository<MemorySize>(_dbContext));
            }
        }

        public IRepository<Provider> Providers
        {
            get
            {
                return providers ??
                    (providers = new Repository<Provider>(_dbContext));
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return orders ??
                    (orders = new Repository<Order>(_dbContext));
            }
        }

        public IRepository<Status> Statuses
        {
            get
            {
                return statuses ??
                    (statuses = new Repository<Status>(_dbContext));
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return users ??
                    (users = new Repository<User>(_dbContext));
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                return roles ??
                    (roles = new Repository<Role>(_dbContext));
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}