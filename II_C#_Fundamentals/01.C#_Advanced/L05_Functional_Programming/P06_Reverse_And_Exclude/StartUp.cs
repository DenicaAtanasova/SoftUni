using System;
using System.Linq;

namespace P06_Reverse_And_Exclude
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var divisor = int.Parse(Console.ReadLine());

            var filter = CreateFilter(divisor);
            Console.WriteLine(string.Join(" ", numbers.Where(x => filter(x)).Reverse()));
        }

        public static Predicate<int> CreateFilter(int divisor)
        {
            return x => x % divisor != 0;
        }
    }
}
