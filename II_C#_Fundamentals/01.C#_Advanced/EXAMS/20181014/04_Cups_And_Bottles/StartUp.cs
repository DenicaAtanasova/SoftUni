using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Cups_And_Bottles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var cups = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var bottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                if(bottles.Last() >= cups[0])
                {
                    wastedWater += bottles.Last() - cups[0];
                    cups.RemoveAt(0);
                }
                else
                {
                    cups[0] -= bottles.Last();
                }
                
                bottles.RemoveAt(bottles.Count - 1);
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
