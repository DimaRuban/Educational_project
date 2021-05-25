using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class AccountUi : IAccountUi
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

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
                _display.PrintForDisplay("Введите ваше имя: ");
                FirstName = Console.ReadLine();

                _display.PrintForDisplay("Введите вашу фамилию: ");
                LastName = Console.ReadLine();

                _display.PrintForDisplay("Введите email: ");
                EmailAddress = Console.ReadLine();

                _display.PrintForDisplay("Введите номер телефона: ");
                PhoneNumber = Console.ReadLine();

                _display.PrintForDisplay("Введите имя пользователя: ");
                UserName = Console.ReadLine();
                if (_validator.CheckingUserName(UserName) != true)
                    RegistrationUi();

                _display.PrintForDisplay("Введите пароль: ");
                Password = Console.ReadLine();

                _accountController.Registration(FirstName, LastName, EmailAddress, PhoneNumber, UserName, Password);
                InformAboutSuccessUi();
            }
            catch (FormatException e)
            {
                _display.PrintForDisplay(e.Message + "\n");
                _accountController.Registration(FirstName, LastName, EmailAddress, PhoneNumber, UserName, Password);
            }
        }
        public void InformAboutSuccessUi()
        {
            _display.PrintForDisplay($"\n{FirstName}, Ваш профиль успешно создан!\n");
        }
    }
}