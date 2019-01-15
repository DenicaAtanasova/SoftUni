using System;
using System.Linq;

namespace P02_Knights_Of_Honor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine($"Sir {x}");

            var people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            people.ToList().ForEach(print);
        }
    }
}
