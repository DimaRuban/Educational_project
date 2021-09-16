using StorePhone.Models;
using StorePhone.Сontracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhone.Data
{
    public class Cache : ICache
    {
        public List<Product> DataCache { get; set; }

        public Cache()
        {
            DataCache = new List<Product>();
        }
    }
}