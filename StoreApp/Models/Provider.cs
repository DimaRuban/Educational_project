using System.Collections.Generic;

namespace StoreApp.Models
{
    public class Provider
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public List<Product> Products { get; set; }
    }
}