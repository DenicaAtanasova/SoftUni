using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Basic_Stack_Operations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            var numbers = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < input[0]; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < input[1]; i++)
            {
                stack.Pop();
            }

            string output = "";
            if (stack.Count == 0)
            {
                output = "0";
            }
            else if (stack.Contains(input[2]))
            {
                output = "true";
            }
            else
            {
                output = stack.Min().ToString();
            }

            Console.WriteLine(output);
        }
    }
}
