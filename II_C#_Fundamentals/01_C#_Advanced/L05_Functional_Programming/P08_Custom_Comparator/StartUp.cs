using System;
using System.Linq;

namespace P08_Custom_Comparator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Action<int[]> print = p => Console.WriteLine(string.Join(" ", p));

            Func<int, int, int> sortFunc = (a, b) =>
                                (a % 2 == 0 && b % 2 != 0) ? -1 :
                                (a % 2 != 0 && b % 2 == 0) ? 1 :
                                a.CompareTo(b);

            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, new Comparison<int>(sortFunc));

            print(numbers);
        }
    }
}
