using StorePhone.Models;
using StorePhone.Сontracts;
using System;
using System.Linq;

namespace StorePhone.Controllers
{
    public class AccountController : IAccountController
    {       
        private readonly IDbContext _dbContext;
        private readonly ILogger _logger;

        private const string Role = "User";

        public AccountController(IDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Register(string firstName, string lastName, string emailAddress, string phoneNumber, string userName, string password)
        {
            var newUserId = _dbContext.Users.Max(x => x.Id) + 1;
            
            if(!IsUserExists(userName))
            {
                _dbContext.Users.Add(new User(newUserId, firstName, lastName, emailAddress, phoneNumber, userName, password, new Role { Name = Role }));
                _logger.Log($"{DateTime.Now} - был добавлен новый пользователь, с ID = {newUserId}");
            }
        }

        private bool IsUserExists(string userName)
        {         
            return _dbContext.Users.Any(user => user.UserName == userName);
        }
    }
}