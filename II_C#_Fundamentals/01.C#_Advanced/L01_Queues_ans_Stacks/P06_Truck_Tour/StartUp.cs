using System;
using System.Collections.Generic;

namespace P06_Truck_Tour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();

            for (int i = 0; i < num; i++)
            {
                queue.Enqueue(Console.ReadLine());
            }

            int index = 0;
            var petrolAmount = 0;
            var distance = 0;

            for (int i = 0; i < num; i++)
            {
                var pompInfo = queue.Peek().Split();
                petrolAmount += int.Parse(pompInfo[0]);
                distance += int.Parse(pompInfo[1]);

                queue.Enqueue(queue.Dequeue());

                if (distance > petrolAmount)
                {
                    index = i + 1;
                    petrolAmount = 0;
                    distance = 0;
                    continue;
                }               
            }

            Console.WriteLine(index);
        }
    }
}
