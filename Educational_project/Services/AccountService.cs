using EF_Store.Data.Contracts;
using EF_Store.Domain;
using StorePhone.Сontracts;
using System;
using System.Collections.Generic;

namespace StorePhone.Controllers
{
    public class AccountService : IAccountService
    {       
        private readonly IUnitOfWork _dbContext;
        private readonly ILogger _logger;

        private const string Role = "User";

        public AccountService(IUnitOfWork dbContext)
        {
            _dbContext = dbContext;
        }

        public AccountService(IUnitOfWork dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Register(string firstName, string lastName, string emailAddress, string phoneNumber, string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void Register(User user)
        {
            _dbContext.Users.CreateObject(user);
            _dbContext.Save();
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.GetObjects();
        }        
    }
}