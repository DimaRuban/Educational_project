using System.Collections.Generic;

namespace EF_Store.Domain
{
    public class Provider
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}