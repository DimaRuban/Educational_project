using StorePhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhone.Сontracts
{
    public interface IDbContext 
    {
        public List<User> Users { get; set; }

        public List<Order> Orders { get; set; }

        public List<Product> Products { get; set; }
    }
}
