using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhone.Models
{
    public class User
    {
        public User()
        {          
        }

        public User(int id, string firstName, string lastName, string emailAdress, string phoneNumber, string userName, string password, Role role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAdress = emailAdress;
            PhoneNumber = phoneNumber;
            UserName = userName;
            Password = password;
            Role = role;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAdress { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
