using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01MaxSequenceEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int sequanceCount = 1;
            int maxSequenceCount = 0;
            int index = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                
                if (numbers[i] == numbers[i - 1])
                {
                    sequanceCount++;
                }
                else
                {
                    sequanceCount = 1;
                }
                if (sequanceCount > maxSequenceCount)
                {
                    maxSequenceCount = sequanceCount;
                    index = i - sequanceCount + 1;
                }
                if (maxSequenceCount == 1)
                {
                    index = 0;
                }
            }
            for (int j = index; j < maxSequenceCount + index; j++)
            {
                Console.Write(numbers[j] + " ");
            }
            Console.WriteLine();
         }
    }
}
