using StorePhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StorePhone.Controllers
{
    public static class AccountController
    {
        public static void Registration()
        {
            try {

                int newUserId = DbContext.users.Count + 1;

                Console.Write("Введите ваше имя: ");
                string firstName = Console.ReadLine();

                Console.Write("Введите вашу фамилию: ");
                string lastName = Console.ReadLine();

                Console.Write("Введите email: ");
                string email = Console.ReadLine();                         
               
                Console.Write("Введите номер телефона: ");
                string phoneNumber = Console.ReadLine();            
             
                Console.Write("Введите имя пользователя: ");
                string userName = Console.ReadLine();

                foreach (var user in DbContext.users)
                {
                     if (user.UserName == userName)
                     {
                        Console.WriteLine("\nЭто имя пользователя уже занято, выберете другое!\n");
                        Registration();
                     }
                }

                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();

                string role = "User";

                DbContext.users.Add(new User(newUserId, firstName, lastName, email, phoneNumber, userName, password, new Role { Name = role }));

                Console.WriteLine($"\n{firstName}, Ваш профиль успешно создан!\n");        
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + "\n");
                Registration();
            }
        }
    }
}
