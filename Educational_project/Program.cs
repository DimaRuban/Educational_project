using StorePhone;
using System;

namespace EducationalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext.InitData();
            Console.WriteLine("Здравствуйте! Вас приветствует магазин Store Phone!\n");
            while (true)
            {
                Menu.GetMenu();
            }
        }
    }
}
