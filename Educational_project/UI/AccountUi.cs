using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class AccountUi : IAccountUi
    {
        private readonly IDisplay _display;
        private readonly IAccountController _accountController;
        private readonly IValidator _validator;

        public AccountUi(IDisplay display, IAccountController accountController, IValidator validator)
        {
            _display = display;
            _accountController = accountController;
            _validator = validator;
        }

        public void RegistrationUi()
        {
            try
            {
                _display.PrintForDisplay("\nВведите ваше имя: ");
                _accountController.FirstName = Console.ReadLine();

                _display.PrintForDisplay("Введите вашу фамилию: ");
                _accountController.LastName = Console.ReadLine();

                _display.PrintForDisplay("Введите email: ");
                _accountController.Email = Console.ReadLine();

                _display.PrintForDisplay("Введите номер телефона: ");
                _accountController.PhoneNumber = Console.ReadLine();
                if (_validator.CheckingPhoneNumber(_accountController.PhoneNumber) == true)
                {
                    _display.PrintForDisplay("\nВведите корректный номер телефона!");
                    RegistrationUi();
                }

                _display.PrintForDisplay("Введите имя пользователя: ");
                _accountController.UserName = Console.ReadLine();
                if (_validator.CheckingUserName(_accountController.UserName) != true)
                    RegistrationUi();

                _display.PrintForDisplay("Введите пароль: ");
                _accountController.Password = Console.ReadLine();

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
            _display.PrintForDisplay($"\n{_accountController.FirstName}, Ваш профиль успешно создан!\n");
        }
    }
}