
using System;
using System.Collections.Generic;

namespace L01_Reverse_Strings
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();

            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
