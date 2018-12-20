using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Reverse_number
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = (Console.ReadLine().Split());

            var stack = new Stack<int>(input.Select(x => int.Parse(x)));

            Console.WriteLine(String.Join(" ", stack));
        }
    }
}
