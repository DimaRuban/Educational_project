using StorePhone.Models;
using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class AccountUi : IAccountUi
    {
        private readonly IDisplay _display;
        private readonly IAccountController _accountController;
        private readonly IValidator _validator;
        private readonly User _user;

        public AccountUi(IDisplay display, IAccountController accountController, IValidator validator, User user)
        {
            _display = display;
            _accountController = accountController;
            _validator = validator;
            _user = user;
        }

        public void RegistrationUi()
        {
            try
            {
                _display.PrintForDisplay("\nВведите ваше имя: ");
                _user.FirstName = Console.ReadLine();

                _display.PrintForDisplay("Введите вашу фамилию: ");
                _user.LastName = Console.ReadLine();

                _display.PrintForDisplay("Введите email: ");
                _user.EmailAddress = Console.ReadLine();

                _display.PrintForDisplay("Введите номер телефона: ");
                _user.PhoneNumber = Console.ReadLine();
                if (_validator.IsPhoneNumberValid(_user.PhoneNumber) != true)
                {
                    _display.PrintForDisplay("\nВведите корректный номер телефона!");
                    RegistrationUi();
                }

                _display.PrintForDisplay("Введите имя пользователя: ");
                _user.UserName = Console.ReadLine();
                if (_validator.IsUserNameValid(_user.UserName) != true)
                    RegistrationUi();

                _display.PrintForDisplay("Введите пароль: ");
                _user.Password = Console.ReadLine();

                _accountController.Registration();
                InformAboutSuccessUi();
            }
            catch (FormatException e)
            {
                _display.PrintForDisplay(e.Message + "\n");
                RegistrationUi();
            }
        }
        public void InformAboutSuccessUi()
        {
            _display.PrintForDisplay($"\n{_user.FirstName}, Ваш профиль успешно создан!\n");
        }
    }
}