using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class Display : IDisplay
    {
        public void PrintForDisplay(string message)
        {
            Console.Write(message);
        }
    }
}
