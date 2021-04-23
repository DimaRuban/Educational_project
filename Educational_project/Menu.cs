﻿using StorePhone.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhone
{
    public static class Menu
    {
        public static void GetMenu()
        {
            try
            {
                Console.Write("\n\n*********МЕНЮ*********\n\nПросмотреть товар - 1,\nДобавить товар - 2,\nКупить товар - 3,\nЗарегистрироваться - 0\n\nВыберете дейсвие из списка: ");
                int operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ProductController.PrintProduct();
                        break;
                    case 2:
                        ProductController.AddNewProduct();
                        break;
                    case 3:
                        OrderController.ChoiceProduct();
                        break;
                    case 0:
                        AccountController.Registration();
                        break;

                    default:
                        Console.WriteLine("\nВыбирете операцию из списка!");
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + "\n");
                Menu.GetMenu();
            }
        }
    }
}
