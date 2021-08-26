using System.Collections.Generic;

namespace EF_Store.Domain
{
    public class Color
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}