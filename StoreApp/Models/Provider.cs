using System.Collections.Generic;

namespace StoreApp.Models
{
    public class Provider
    {
        public Provider()
        {               
        }

        public Provider(int id, string name, List<Category> category, List<Product> product)
        {
            Id = id;
            Name = name;
            Category = category;
            Product = product;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Category> Category { get; set; }

        public List<Product> Product  { get; set; }

    }
}