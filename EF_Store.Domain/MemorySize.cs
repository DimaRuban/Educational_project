using System.Collections.Generic;

namespace EF_Store.Domain
{
    public class MemorySize
    {
        public int Id { get; set; }

        public int Size { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}