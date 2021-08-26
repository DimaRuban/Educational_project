using System.Collections.Generic;

namespace EF_Store.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageName { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public int MemorySizeId { get; set; }
        public MemorySize MemorySize { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public List<Order> Orders = new List<Order>();
    }  
}