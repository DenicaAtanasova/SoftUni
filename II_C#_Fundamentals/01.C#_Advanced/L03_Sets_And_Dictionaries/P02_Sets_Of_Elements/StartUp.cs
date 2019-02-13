using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Sets_Of_Elements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var length = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstSet = new HashSet<int>();
            while (length[0]-- > 0)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            var secondSet = new HashSet<int>();
            while (length[1]-- > 0)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var num in firstSet)
            {
                if (secondSet.Contains(num))
                {
                    Console.Write(num + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
