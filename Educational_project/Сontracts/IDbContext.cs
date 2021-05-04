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
        public List<Product> products { get; set; }

        public List<Order> orders { get; set; }

        public List<User> users { get; set; }

        public void InitData() { }
    }
}
