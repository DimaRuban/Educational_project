using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhone.Models
{
    public class Product
    {
        public Product()
        {       
        }

        public Product(int id ,string name, decimal price, Color color, MemorySize memorySize)
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

        public Color Color { get; set; }

        public MemorySize MemorySize { get; set; }  
        
        public Category Category { get; set; }

        public string ImageName { get; set; }
    }
}
