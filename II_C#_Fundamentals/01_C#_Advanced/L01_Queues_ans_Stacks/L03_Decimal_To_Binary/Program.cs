using System;
using System.Collections.Generic;

namespace L03_Decimal_To_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                Console.WriteLine(input);
            }

            var stack = new Stack<int>();

            while (input > 0)
            {
                stack.Push(input % 2);

                input /= 2;
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
