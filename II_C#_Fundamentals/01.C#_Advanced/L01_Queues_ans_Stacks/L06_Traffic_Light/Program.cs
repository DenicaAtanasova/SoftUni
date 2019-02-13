using System;
using System.Collections.Generic;

namespace L06_Traffic_Light
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var car = string.Empty;
            var queue = new Queue<string>();
            int carsCounter = 0;

            while ((car = Console.ReadLine()) != "end")
            {
                if (car == "green")
                {
                    if (queue.Count < numberOfCars)
                    {
                        numberOfCars = queue.Count;
                    }

                    for (int i = 0; i < numberOfCars; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        carsCounter++;
                    }
                }
                else
                {
                    queue.Enqueue(car);
                }             
            }

            Console.WriteLine($"{carsCounter} cars passed the crossroads.");
        }
    }
}
