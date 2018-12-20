using System;
using System.Collections.Generic;

namespace P08_Stack_Fibonacci
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < n; i++)
            {
                long num2 = stack.Pop();
                long num1 = stack.Peek() + num2;

                stack.Push(num2);
                stack.Push(num1);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
