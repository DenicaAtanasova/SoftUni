using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Periodic_Table
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var periodicTable = new HashSet<string>();

            while (n-- > 0)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in input)
                {
                    periodicTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable.OrderBy(x => x)));
        }
    }
}
