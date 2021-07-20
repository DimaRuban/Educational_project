using System.Collections.Generic;

namespace StoreApp.Models
{
    public class Product
    {
        public Product()
        {
        }
       
        public Product(int id, string name, string description, decimal price, Color color, MemorySize memorySize, Category category, Provider provider)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Color = color;
            MemorySize = memorySize;
            Category = category;
            Provider = provider;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Color Color { get; set; }

        public MemorySize MemorySize { get; set; }

        public Category Category { get; set; }

        public Provider Provider  { get; set; }

        public string ImageName { get; set; }
    }
}