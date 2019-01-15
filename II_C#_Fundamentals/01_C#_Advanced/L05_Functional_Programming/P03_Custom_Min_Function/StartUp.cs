using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Custom_Min_Function
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<IEnumerable<int>, int> findMinValue = x => x.Min();

            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            Console.WriteLine(findMinValue(numbers));
        }
    }
}
