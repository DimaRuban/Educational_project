using System;

namespace Delivery_discount
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWork homeWork = new HomeWork();
            Console.WriteLine(homeWork.InvokePriceCalculatiion());
            Console.ReadKey();
        }
    }
}