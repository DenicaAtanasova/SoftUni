using System;
using System.Collections.Generic;
using System.Linq;

namespace L02_SImple_Calculator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var stack = new Stack<string>(input.Reverse());
            var stack2 = new Stack<string>(input);

            while (stack.Count > 1)
            {
                var first = int.Parse(stack.Pop());
                var op = stack.Pop();
                var second = int.Parse(stack.Pop());

                switch (op)
                {
                    case "-":
                        stack.Push((first - second).ToString());
                        break;
                    case "+":
                        stack.Push((first + second).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
