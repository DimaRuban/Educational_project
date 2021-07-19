using System.Collections.Generic;

namespace StoreApp.Models
{
    public class Product
    {
        public Product()
        {
        }
        public Product(int id, string name, decimal price, List<Color> color, List<MemorySize> memorySize)
        {
            Id = id;
            Name = name;
            Price = price;
            Color = color;
            MemorySize = memorySize;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public List<Color> Color { get; set; }

        public List<MemorySize> MemorySize { get; set; }

        public Category Category { get; set; }

        public string ImageName { get; set; }
    }
}