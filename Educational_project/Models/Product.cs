﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_with_models.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int ColorId { get; set; }
        public int MemoryId { get; set; }   
        public int CategoryId { get; set; }
        public string ImageName { get; set; }
    }
}
