using StorePhone.Models;
using System.Collections.Generic;

namespace StorePhone.Сontracts
{
    public interface ICacheService
    {
        Queue<Product> Products { get; set; }
        void Get();
        void Set();
    }
}