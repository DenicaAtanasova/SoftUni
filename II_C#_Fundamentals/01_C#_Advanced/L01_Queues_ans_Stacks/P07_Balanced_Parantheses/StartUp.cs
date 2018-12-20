using System;
using System.Collections.Generic;

namespace P07_Balanced_Parantheses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();

            var openedParantheses = "({[";
            var closedParantheses = ")}]";

            for (int i = 0; i < input.Length; i++)
            {
                if (openedParantheses.Contains(input[i]))
                {
                    stack.Push(openedParantheses.IndexOf(input[i]));
                }

                if (closedParantheses.Contains(input[i]))
                {
                    var index = closedParantheses.IndexOf(input[i]);

                    if (stack.Peek() != index)
                    {
                        break;
                    }

                    stack.Pop();
                }
            }

            Console.WriteLine(stack.Count != 0 ? "NO" : "YES");
        }
    }
}
