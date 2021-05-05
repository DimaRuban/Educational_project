using StorePhone.Models;
using StorePhone.Сontracts;

namespace StorePhone.Controllers
{
    public class AccountController : IAccountController
    {
        private readonly IDbContext _dbContext;
        private readonly IValidator _validator;
        private readonly IAccountUi _accountUi;
        public AccountController(IDbContext dbContext, IValidator validator, IAccountUi accountUi)
        {
            _dbContext = dbContext;
            _validator = validator;
            _accountUi = accountUi;
        }
        public void Registration()
        {
            _accountUi.RegistrationUi();

            int newUserId = _dbContext.Users.Count + 1;

            if (_validator.CheckingUserName(_accountUi.UserName) != true)
                Registration();

            string role = "User";

            _dbContext.Users.Add(new User(newUserId, _accountUi.FirstName, _accountUi.LastName, _accountUi.Email, _accountUi.PhoneNumber, _accountUi.UserName, _accountUi.Password, new Role { Name = role }));

            _accountUi.InformAboutSuccess();
        }
    }
}