using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Basic_Queue_Operations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().
                Split()
                .Select(x => int.Parse(x))
                .ToArray();

            var numbers = Console.ReadLine().
                Split()
                .Select(x => int.Parse(x))
                .ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < input[0]; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < input[1]; i++)
            {
                queue.Dequeue();
            }

            string result = string.Empty;

            if (queue.Count == 0)
            {
                result = "0";
            }
            else if (queue.Contains(input[2]))
            {
                result = "true";
            }
            else
            {
                result = queue.Min().ToString();
            }

            Console.WriteLine(result);
        }
    }
}
