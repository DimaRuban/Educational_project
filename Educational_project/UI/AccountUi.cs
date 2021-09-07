using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class AccountUi : IAccountUi
    {
        private readonly IDisplay _display;
        private readonly IAccountService _accountController;
        private readonly IValidator _validator;

        public AccountUi(IDisplay display, IAccountService accountController, IValidator validator)
        {
            _display = display;
            _accountController = accountController;
            _validator = validator;
        }

        public void RegisterUi()
        {
            try
            {
                _display.Print("Введите ваше имя: ");
                string firstName = Console.ReadLine();

                _display.Print("Введите вашу фамилию: ");
                string lastName = Console.ReadLine();

                _display.Print("Введите email: ");
                string emailAddress = Console.ReadLine();

                _display.Print("Введите номер телефона: ");
                string phoneNumber = Console.ReadLine();
                if (!_validator.IsPhoneNumberValid(phoneNumber))
                {
                    _display.Print("\nВведите корректный номер телефона!");
                    RegisterUi();
                }

                _display.Print("Введите имя пользователя: ");
                string userName = Console.ReadLine();
            
                _display.Print("Введите пароль: ");
                string password = Console.ReadLine();

                _accountController.Register(firstName, lastName, emailAddress, phoneNumber, userName, password);
                InformAboutSuccessUi(firstName);
            }
            catch (FormatException e)
            {
                _display.Print(e.Message + "\n");
                RegisterUi();
            }
        }

        private void InformAboutSuccessUi(string firstName)
        {
            _display.Print($"\n{firstName}, Ваш профиль успешно создан!\n");
        }
    }
}