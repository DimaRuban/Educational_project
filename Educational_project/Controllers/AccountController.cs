using StorePhone.Models;
using StorePhone.Сontracts;
using System.Linq;

namespace StorePhone.Controllers
{
    public class AccountController : IAccountController
    {
        private readonly IDbContext _dbContext;
        private readonly User _user;

        public AccountController(IDbContext dbContext, User user)
        {
            _dbContext = dbContext;
            _user = user;
        }
        public void Registration()
        {
            int newUserId = _dbContext.Users.Max(x => x.Id) + 1;

            string role = "User";

            _dbContext.Users.Add(new User(newUserId, _user.FirstName, _user.LastName, _user.EmailAddress, _user.PhoneNumber, _user.UserName, _user.Password, new Role { Name = role }));
        }
    }
}