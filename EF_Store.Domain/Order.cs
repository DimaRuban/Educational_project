using System;
using System.Collections.Generic;

namespace EF_Store.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }

        public decimal DeliveryCost { get; set; }


        public int StatusId { get; set; }
        public Status Status { get; set; }

        public List<Product> Products = new List<Product>();
    }
}