
namespace P01HelloName
{
    using System;

    class StartUp
    {
        private static void Main(string[] args)
        {
            PrintName(Console.ReadLine());
        }

        private static void PrintName(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
