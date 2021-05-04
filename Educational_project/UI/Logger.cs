using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class Logger : ILogger
    {
        public void PrintForDisplay(string message)
        {
            Console.Write(message);
        }
    }
}
