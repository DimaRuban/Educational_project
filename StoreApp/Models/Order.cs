using System;

namespace StoreApp.Models
{
    public class Order
    {
        public Order()
        {
        }

        public Order(int id, DateTime createdAt, User user, string address, int quantity, decimal totalPrice, decimal deliveryCost, Status status)
        {
            Id = id;
            CreatedAt = createdAt;
            User = user;
            Address = address;
            Quantity = quantity;
            TotalPrice = totalPrice;
            DeliveryCost = deliveryCost;
            Status = status;
        }

        public int Id { get; set; }

        public User User { get; set; }
        
        public Product Product { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }

        public decimal DeliveryCost { get; set; }

        public Status Status { get; set; }
    }
}