using EF_Store.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePhoneAPI.Filters
{
    public class ProductsHelper
    {
        public static HtmlString PrintProducs (IEnumerable<Product> products)
        {
            var result = string.Empty;
            foreach (var product in products)
            {
                result += "<tr>";
                result += $"<td>{product.Id}</td>";
                result += $"<td>{product.Name}</td>";
                result += $"<td>{product.Description}</td>";
                result += $"<td>{product.Price}</td>";
                result += $"<td>{product.Description}</td>";
                result += $"<td>{product.MemorySize.Size}</td>";
                result += $"<td>{product.Color.Name}</td>";
                result += $"<td>{product.Category.Name}</td>";
                result += $"<td>{product.Provider.Name}</td>";              
                result += "</tr>";
            }
            return new HtmlString(result);
        }
    }
}