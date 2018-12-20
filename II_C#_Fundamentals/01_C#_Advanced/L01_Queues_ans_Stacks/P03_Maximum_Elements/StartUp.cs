using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Maximum_Elements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine()
                    .Split().
                    Select(x => int.Parse(x))
                    .ToArray();

                var command = input[0];

                switch (command)
                {
                    case 1:
                        stack.Push(input[1]);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        Console.WriteLine(stack.Max());
                        break;
                }
            }          
        }
    }
}
