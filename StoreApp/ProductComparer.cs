using StoreApp.Models;
using System.Collections.Generic;

namespace StoreApp
{
    public class ProductComparer : EqualityComparer<Product>
     {
          public override bool Equals(Product product1, Product product2)
          {
                return product1?.Category.Name == product2?.Category.Name;
          }
          public override int GetHashCode(Product product)
          {
                return product.Category.Name.GetHashCode();
          }
     }
}