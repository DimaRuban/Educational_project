using StorePhone.Models;
using StorePhone.Сontracts;
using System.Linq;

namespace StorePhone.Controllers
{
    public class AccountController : IAccountController
    {
        private readonly IDbContext _dbContext;

        public AccountController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Register(string firstName, string lastName, string emailAddress, string phoneNumber, string userName, string password)
        {
            var newUserId = _dbContext.Users.Max(x => x.Id) + 1;

            string role = "User";

            _dbContext.Users.Add(new User(newUserId, firstName, lastName, emailAddress, phoneNumber, userName, password, new Role { Name = role }));
        }
    }
}