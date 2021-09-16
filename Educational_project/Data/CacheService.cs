using StorePhone.Models;
using StorePhone.Сontracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorePhone.Data
{
    public class CacheService : ICacheService
    {
        private readonly Cache _cache;
        private static readonly object _locker = new object();

        public CacheService(Cache cache)
        {
            _cache = cache;
        }

        public CacheService()
        {        
        }

        public IEnumerable<Product> Get()
        {
            lock (_locker)
            {
                if (_cache.DataCache.Count != 0)
                {
                    while (_cache.DataCache.Count < 5)
                    {
                        return _cache.DataCache;
                    }              
                } 
                return _cache.DataCache;
            }
        }

        public void Set(Product product)
        {
            lock (_locker)
            {
                if (_cache.DataCache.Count == 5)
                {
                    _cache.DataCache.RemoveAt(0);
                }
                else
                {
                    _cache.DataCache.Add(product);
                }
            }
        }
    }
}