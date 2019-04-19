using System;
using System.Linq;
using System.Collections.Generic;

namespace _01_Catapult_Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            var pilesCount = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            var walls = new List<int>(input);
            var rocks = new List<int>();

            for (int i = 1; i <= pilesCount; i++)
            {
                var rocksPower = Console.ReadLine()
                .Split()
                .Select(int.Parse);

                if (i % 3 == 0)
                {
                    var newWall = int.Parse(Console.ReadLine());
                    walls.Add(newWall);
                }

                if (walls.Count == 0)
                {
                    break;
                }

                rocks.AddRange(rocksPower);

                while (rocks.Count > 0 && walls.Count > 0)
                {
                    var lastIndex = rocks.Count - 1;
                    if (rocks[lastIndex] > walls[0])
                    {
                        rocks[lastIndex] -= walls[0];
                        walls.RemoveAt(0);
                    }
                    else if (rocks[lastIndex] < walls[0])
                    {
                        walls[0] -= rocks[lastIndex];
                        rocks.RemoveAt(lastIndex);
                    }
                    else
                    {
                        walls.RemoveAt(0);
                        rocks.RemoveAt(lastIndex);
                    }
                }
            }
            
            if (rocks.Count > 0)
            {
                rocks.Reverse();
                Console.WriteLine($"Rocks left: {string.Join(", ", rocks)}");
            }
            else
            {
                Console.WriteLine($"Walls left: {string.Join(", ", walls)}");
            }
        }
    }
}
