using System;
using System.Collections.Generic;
using StoreApp.Models;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Apple = new Provider()
            {
                Id = 1,
                Name = "Apple",
                Category = new List<Category>()
                { 
                    new Category() 
                    { 
                        Id = 1, 
                        Name = "Iphone" 
                    } 
                },
                Product = new List<Product>()
                { 
                    new Product() 
                    {
                        Id = 1, 
                        Name = "Iphone 11", 
                        Category = new Category() 
                        {
                            Id = 1, 
                            Name = "Iphone",
                        }, 
                        Description = "text", 
                        Color = new List<Color>() 
                        {
                            new Color() 
                            { 
                                Id = 1, 
                                Name = "Black", 
                            }, 
                        }, 
                        MemorySize = new List<MemorySize>() 
                        {
                            new MemorySize() 
                            { 
                                Id = 1, 
                                Size = 64,
                            },
                        } 
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "Iphone 11",
                        Category = new Category()
                        {
                            Id = 1,
                            Name = "Iphone",
                        },
                        Description = "text",
                        Color = new List<Color>()
                        {
                            new Color()
                            {
                                Id = 2,
                                Name = "Red",
                            },
                        },
                        MemorySize = new List<MemorySize>()
                        {
                            new MemorySize()
                            {
                                Id = 2,
                                Size = 128,
                            },
                        }
                    },
                    new Product()
                    {
                        Id = 3,
                        Name = "Iphone 11 Pro",
                        Category = new Category()
                        {
                            Id = 1,
                            Name = "Iphone",
                        },
                        Description = "text",
                        Color = new List<Color>()
                        {
                            new Color()
                            {
                                Id = 3,
                                Name = "Green",
                            },
                        },
                        MemorySize = new List<MemorySize>()
                        {
                            new MemorySize()
                            {
                                Id = 3,
                                Size = 256,
                            },
                        }
                    },
                    new Product()
                    {
                        Id = 4,
                        Name = "Iphone 12",
                        Category = new Category()
                        {
                            Id = 1,
                            Name = "Iphone",
                        },
                        Description = "text",
                        Color = new List<Color>()
                        {
                            new Color()
                            {
                                Id = 4,
                                Name = "Blue",
                            },
                        },
                        MemorySize = new List<MemorySize>()
                        {
                            new MemorySize()
                            {
                                Id = 4,
                                Size = 512,
                            },
                        }
                    },
                    new Product()
                    {
                        Id = 5,
                        Name = "Iphone 12 Pro",
                        Category = new Category()
                        {
                            Id = 1,
                            Name = "Iphone",
                        },
                        Description = "text",
                        Color = new List<Color>()
                        {
                            new Color()
                            {
                                Id = 5,
                                Name = "White",
                            },
                        },
                        MemorySize = new List<MemorySize>()
                        {
                            new MemorySize()
                            {
                                Id = 5,
                                Size = 128,
                            },
                        },
                    },
                },
            };
        }
    }
}