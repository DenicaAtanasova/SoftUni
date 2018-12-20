using System;
using System.Collections.Generic;

namespace P05_Calculate_Sequence
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var num = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(num);

            for (int i = 0; i < 50; i++)
            {
               
                queue.Enqueue(queue.Peek() + 1);
                queue.Enqueue(2 * queue.Peek() + 1);
                queue.Enqueue(queue.Peek() + 2);

                Console.Write(queue.Dequeue() + " ");
            }

            Console.WriteLine();
        }
    }
}
