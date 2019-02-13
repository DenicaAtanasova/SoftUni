using System;
using System.Linq;

namespace P01_Action_Print
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x);

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            names.ToList().ForEach(print);
        }
    }
}
