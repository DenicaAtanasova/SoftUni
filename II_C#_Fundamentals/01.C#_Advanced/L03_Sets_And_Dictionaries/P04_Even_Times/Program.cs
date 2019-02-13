using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = new Dictionary<int, int>();

            while (n-- > 0)
            {
                var number = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }
            }

            Console.WriteLine(numbers.First(x => x.Value % 2 == 0).Key);
        }
    }
}
