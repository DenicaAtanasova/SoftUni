using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_List_Of_Predicates
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int range = int.Parse(ReadLine());

            var divisors = ReadLine()
                           .Split()
                           .Distinct()
                           .Select(int.Parse)
                           .ToList();

            List<Predicate<int>> predicates = divisors.Select(div => (Predicate<int>)(n => n % div == 0))
                                                      .ToList();

            for (int j = 1; j <= range; j++)
            {
                bool isDivisable = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(j))
                    {
                        isDivisable = false;
                        break;
                    }
                }

                if (isDivisable)
                {
                    Write("{0} ", j);
                }
            }
        }
    }
}
