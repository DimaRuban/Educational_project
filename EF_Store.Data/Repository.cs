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
            T objectToDelete = _dbContext.Set<T>().Find(id);
            if (objectToDelete != null)
            {
                _dbContext.Set<T>().Remove(objectToDelete);
            }
        }

        public T GetObject(int id)
        {
            return _dbContext.Find<T>(id);
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