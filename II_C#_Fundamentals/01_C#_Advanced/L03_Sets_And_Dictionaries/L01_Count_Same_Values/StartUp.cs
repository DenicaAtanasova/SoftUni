using System;
using System.Collections.Generic;
using System.Linq;

namespace L01_Count_Same_Values
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var numbers = new Dictionary<double, int>();

            foreach (var num in input)
            {
                if (numbers.ContainsKey(num))
                {
                    numbers[num]++;
                }
                else
                {
                    numbers.Add(num, 1);
                }
            }

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
