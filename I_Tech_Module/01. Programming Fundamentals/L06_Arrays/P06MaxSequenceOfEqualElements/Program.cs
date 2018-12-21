using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console
                    .ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            int count = 1;
            int countMax = 0;
            int index = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count > countMax)
                {
                    countMax = count;
                    index = i - count + 1;
                }
            }
            for (int i = index; i < index + countMax; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
