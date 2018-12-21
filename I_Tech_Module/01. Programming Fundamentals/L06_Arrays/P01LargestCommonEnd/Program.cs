using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine().Split(' ').ToArray();
            var arr2 = Console.ReadLine().Split(' ').ToArray();

            int leftCounter = 0;
            int rightCounter = 0;

            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[i] == arr2[i])
                {
                    leftCounter++;
                }
                if (arr1[arr1.Length - i - 1] == arr2[arr2.Length - i - 1])
                {
                    rightCounter++;
                }
            }
            Console.WriteLine(Math.Max(leftCounter, rightCounter));
        }
    }
}
