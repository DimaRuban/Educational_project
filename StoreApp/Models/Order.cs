using System;
using System.Collections.Generic;

namespace StoreApp.Models
{
    public class Order
    {

        public int Id { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public List<Product> Products { get; set; }
        
        public DateTime OrderDataTime { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }

        public decimal DeliveryCost { get; set; }

        public Status Status { get; set; }
    }
}