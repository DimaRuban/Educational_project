using StorePhone.Models;
using StorePhone.UI;
using StorePhone.Data;
using StorePhone.Validation;
using StorePhone.Сontracts;
using System;


namespace StorePhone.Controllers
{
    public class AccountController
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly IValidator _validator;

        public AccountController(IDbContext dbContext, ILogger logger, IValidator validator)
        {
            _dbContext = dbContext;
            _logger = logger;
            _validator = validator;
        }
        public void Registration()
        {          
            try {
               
                int newUserId = _dbContext.users.Count + 1;

                _logger.PrintForDisplay("Введите ваше имя: ");
                string firstName = Console.ReadLine();

                _logger.PrintForDisplay("Введите вашу фамилию: ");
                string lastName = Console.ReadLine();

                _logger.PrintForDisplay("Введите email: ");
                string email = Console.ReadLine();

                _logger.PrintForDisplay("Введите номер телефона: ");
                string phoneNumber = Console.ReadLine();

                _logger.PrintForDisplay("Введите имя пользователя: ");
                string userName = Console.ReadLine();

                foreach (var user in _dbContext.users)
                {
                     if (user.UserName == userName)
                     {
                        _logger.PrintForDisplay("\nЭто имя пользователя уже занято, выберете другое!\n");
                        Registration();
                     }
                }

                _logger.PrintForDisplay("Введите пароль: ");
                string password = Console.ReadLine();

                string role = "User";

                _dbContext.users.Add(new User(newUserId, firstName, lastName, email, phoneNumber, userName, password, new Role { Name = role }));

                _logger.PrintForDisplay($"\n{firstName}, Ваш профиль успешно создан!\n");        
            }
            catch (FormatException e)
            {
                _logger.PrintForDisplay(e.Message + "\n");
                Registration();
            }
        }
    }
}