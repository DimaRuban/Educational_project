using System;

namespace FirstTask
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
