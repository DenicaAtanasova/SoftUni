using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x));

            var plants = new Queue<int>(input);

            int daysCounter = 0;

            while (true)
            {
                int leftPlantPesticideAmount = 0;

                for (int i = 1; i < n; i++)
                {
                    if (leftPlantPesticideAmount == 0)
                    {
                        leftPlantPesticideAmount = plants.Dequeue();
                        plants.Enqueue(leftPlantPesticideAmount);
                    }

                    if (leftPlantPesticideAmount < plants.Peek())
                    {
                        leftPlantPesticideAmount = plants.Dequeue();
                    }
                    else
                    {
                        leftPlantPesticideAmount = 0;
                    }
                }

                if (n == plants.Count)
                {
                    break;
                }
                else
                {
                    n = plants.Count();
                    daysCounter++;
                }

                if (leftPlantPesticideAmount == 0)
                {
                    plants.Enqueue(plants.Dequeue());
                }
            }

            Console.WriteLine(daysCounter);
        }
    }
}
