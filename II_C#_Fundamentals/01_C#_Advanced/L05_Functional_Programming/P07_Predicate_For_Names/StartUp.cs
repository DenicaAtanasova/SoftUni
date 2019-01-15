using System;
using System.Linq;

namespace P07_Predicate_For_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Predicate<string> filterByLength = x => x.Length <= length;

            Console.ReadLine()
                .Split()
                .Where(s => filterByLength(s))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
