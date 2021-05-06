using StorePhone.Models;
using StorePhone.Сontracts;

namespace StorePhone.Controllers
{
    public class AccountController : IAccountController
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        private readonly IDbContext _dbContext;

        public AccountController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Registration()
        {
            int newUserId = _dbContext.Users.Count + 1;
           
            string role = "User";

            _dbContext.Users.Add(new User(newUserId, FirstName, LastName, Email, PhoneNumber, UserName, Password, new Role { Name = role }));
        }
    }
}