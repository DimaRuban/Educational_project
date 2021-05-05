using System;

namespace StorePhone.Models
{
    public class Order
    {
        public Order(int id, DateTime createdAt, User user, Product product, string address, int quantity, decimal totalPrice  )
        {
            Id = id;
            CreatedAt = createdAt;
            User = user;
            Product = product;
            Address = address;
            Quantity = quantity;
            TotalPrice = totalPrice;         
        }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
