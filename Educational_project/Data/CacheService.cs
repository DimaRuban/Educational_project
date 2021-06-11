using StorePhone.Models;
using StorePhone.Сontracts;
using System;
using System.Collections.Generic;

namespace StorePhone.Data
{
    public class CacheService : ICacheService
    {
        public Queue<Product> Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Set()
        {
            throw new NotImplementedException();
        }
    }
}