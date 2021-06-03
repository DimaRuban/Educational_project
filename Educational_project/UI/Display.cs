using StorePhone.Сontracts;
using System;

namespace StorePhone.UI
{
    public class Display : IDisplay
    {
        public void Print(string message)
        {
            Console.Write(message);
        }
    }
}
