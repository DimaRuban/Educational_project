using StorePhone.Models;
using StorePhone.Сontracts;
using System.Linq;

namespace StorePhone.Controllers
{
    public class AccountController : IAccountController
    {
        private readonly IDbContext _dbContext;

        private const string Role = "User";

        public AccountController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Register(string firstName, string lastName, string emailAddress, string phoneNumber, string userName, string password)
        {
            var newUserId = _dbContext.Users.Max(x => x.Id) + 1;

            if(!IsUserExists(userName))
                _dbContext.Users.Add(new User(newUserId, firstName, lastName, emailAddress, phoneNumber, userName, password, new Role { Name = Role }));        
        }
        private bool IsUserExists(string userName)
        {         
            return _dbContext.Users.Any(user => user.UserName == userName);
        }
    }
}