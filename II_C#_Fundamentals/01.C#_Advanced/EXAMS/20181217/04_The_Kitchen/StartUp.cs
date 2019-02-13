using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_The_Kitchen
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var knives = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var forks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var cutlerySet = new List<int>();

            while (knives.Count > 0 && forks.Count > 0)
            {
                var firstFork = forks[0];
                var lastKnife = knives.Last();

                if (lastKnife > firstFork)
                {
                    cutlerySet.Add(lastKnife + firstFork);
                    knives.RemoveAt(knives.Count -1);
                    forks.RemoveAt(0);
                }
                else if (lastKnife < firstFork)
                {
                    knives.RemoveAt(knives.Count - 1);
                }
                else
                {
                    forks.RemoveAt(0);
                    knives[knives.Count - 1] ++;
                }
            }

            var biggestSet = cutlerySet.OrderByDescending(x => x).First();

            Console.WriteLine($"The biggest set is: {biggestSet}");

            Console.WriteLine(string.Join(" ", cutlerySet));
        }
    }
}
