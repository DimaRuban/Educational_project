using StorePhone.Models;
using System.Collections.Generic;

namespace StorePhone.Сontracts
{
    public interface ICache
    {
        List<Product> DataCache { get; set; }
    }
}