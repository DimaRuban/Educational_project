﻿using StorePhone.Models;
using System.Collections.Generic;

namespace StorePhone.Сontracts
{
    public interface ICacheService
    {
        IEnumerable<Product> Get();
        void Set(Product product);
    }
}