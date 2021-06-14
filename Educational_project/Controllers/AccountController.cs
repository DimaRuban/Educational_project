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

        private const string role = "User";

        public AccountController(IDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Registration(string firstName, string lastName, string emailAddress, string phoneNumber, string userName, string password)
        {
            var newUserId = _dbContext.Users.Max(x => x.Id) + 1;

            _dbContext.Users.Add(new User(newUserId, firstName, lastName, emailAddress, phoneNumber, userName, password, new Role { Name = role }));
            _dbContext.Save();
            _logger.Log($"{DateTime.Now} - был добавлен новый пользователь, с ID = {newUserId}");
        }
    }
}