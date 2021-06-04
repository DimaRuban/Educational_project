using StorePhone.Models;
using System.Collections.Generic;

namespace StorePhone.Сontracts
{
    public interface IDbContext
    {
        List<Product> Products { get; set; }

        List<Order> Orders { get; set; }

        List<User> Users { get; set; }

        void InitData() { }
    }
}
