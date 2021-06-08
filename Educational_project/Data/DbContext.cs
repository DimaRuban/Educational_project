using StorePhone.Models;
using StorePhone.Сontracts;
using System.Collections.Generic;

namespace StorePhone.Data
{
    public  class DbContext : IDbContext
    {
        public List<Product> Products { get; set; }

        public List<Order> Orders { get; set; }

        public List<User> Users { get; set; }

        public List<Currency> Currencies { get; set; }

        public DbContext()
        {
            Products = new List<Product>();
            Orders = new List<Order>();
            Users = new List<User>();
            Currencies = new List<Currency>();
        }
    }
}