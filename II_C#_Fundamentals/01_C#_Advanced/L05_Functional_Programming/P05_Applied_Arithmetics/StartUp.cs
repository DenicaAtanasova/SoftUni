using System;
using System.Linq;

namespace P05_Applied_Arithmetics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    var arithmetics = ApplyArithmetics(command);
                    numbers = numbers.Select(arithmetics).ToArray();
                }
            }
        }

        public static Func<int, int> ApplyArithmetics(string command)
        {
            switch (command)
            {
                case "add":
                    return x => x + 1;
                case "multiply":
                    return x => x * 2;
                case "subtract":
                    return x => x - 1;
                default:
                    return x => x = 0;
            }
        }
    }
}
