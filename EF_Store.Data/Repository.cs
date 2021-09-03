using EF_Store.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EF_Store.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dbContext;

        public Repository(DataContext DbContext)
        {
            _dbContext = DbContext;
        }
        public void CreateObject(T item)
        {
            _dbContext.Add(item);
        }

        public void DeleteObject(int id)
        {
            throw new NotImplementedException();
        }

        public T GetObject(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetObjects()
        {
            return _dbContext.Set<T>();
        }

        public void UpdateObject(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}