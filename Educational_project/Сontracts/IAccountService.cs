using EF_Store.Domain;
using System.Collections.Generic;

namespace StorePhone.Contracts
{
    public interface IAccountService
    {
        void Register(string firstName, string lastName, string emailAddress, string phoneNumber, string userName, string password);

        void Register(User user);

        public IEnumerable<User> GetUsers();
    }
}