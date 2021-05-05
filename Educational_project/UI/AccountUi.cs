using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class AccountUi : IAccountUi
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        private readonly IDisplay _display;

        public AccountUi(IDisplay display)
        {
            _display = display;
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
                Email = Console.ReadLine();

                _display.PrintForDisplay("Введите номер телефона: ");
                PhoneNumber = Console.ReadLine();

                _display.PrintForDisplay("Введите имя пользователя: ");
                UserName = Console.ReadLine();

                _display.PrintForDisplay("Введите пароль: ");
                Password = Console.ReadLine();
            }
            catch (FormatException e)
            {
                _display.PrintForDisplay(e.Message + "\n");
                RegistrationUi();
            }
        }
        public void InformAboutSuccess()
        {
            _display.PrintForDisplay($"\n{FirstName}, Ваш профиль успешно создан!\n");
        }
    }
}
