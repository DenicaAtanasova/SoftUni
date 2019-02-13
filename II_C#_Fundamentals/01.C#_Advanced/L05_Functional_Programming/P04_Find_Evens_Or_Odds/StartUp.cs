using System;
using System.Linq;

namespace P04_Find_Evens_Or_Odds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbers = Enumerable.Range(range[0], range[1] + 1 - range[0]);

            var condition = Console.ReadLine();
            var filter = CreateFilter(condition);

            Console.WriteLine(string.Join(" ", numbers.Where(x => filter(x))));
        }

        public static Predicate<int> CreateFilter(string condition)
        {
            if (condition == "even")
            {
                return x => x % 2 == 0;
            }

            return x => x % 2 != 0;
        }
    }
}
