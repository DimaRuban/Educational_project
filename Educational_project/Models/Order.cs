using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_with_models.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public int UserId { get; set; }    
    }
}
