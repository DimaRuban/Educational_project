using System;

namespace StorePhone.Models
{
    public class Order
    {
        public Order()
        {
        }
        public Order(int id, DateTime createdAt, string user, string phoneNumber, string address, int quantity, decimal totalPrice)
        {
            Id = id;
            CreatedAt = createdAt;
            UserName = user;
            PhoneNumber = phoneNumber;
            Address = address;
            Quantity = quantity;
            TotalPrice = totalPrice;         
        }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
