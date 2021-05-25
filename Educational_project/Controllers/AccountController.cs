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

        public AccountController(IDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public void Registration(string firstName, string lastName, string emailAddress, string phoneNumber, string userName, string password)
        {
            int newUserId = _dbContext.Users.Max(x => x.Id) + 1;

            string role = "User";

            _dbContext.Users.Add(new User(newUserId, firstName, lastName, emailAddress, phoneNumber, userName, password, new Role { Name = role }));
            _logger.Log($"{DateTime.Now} - был добавлен новый пользователь, с ID = {newUserId}");
        }
    }
}