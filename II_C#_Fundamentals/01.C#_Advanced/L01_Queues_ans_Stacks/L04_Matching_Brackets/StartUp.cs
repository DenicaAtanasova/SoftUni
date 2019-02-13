using System;
using System.Collections.Generic;

namespace L04_Matching_Brackets
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    int startIndex = stack.Pop();
                    int length = i - startIndex + 1;
                    var result = input.Substring(startIndex, length);
                    Console.WriteLine(result);
                }               
            }
        }
    }
}
