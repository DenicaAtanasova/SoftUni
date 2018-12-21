using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine().Split(' ').ToArray();
            var arr2 = Console.ReadLine().Split(' ').ToArray();
            int arrLength = arr1.Length.CompareTo(arr2.Length);

            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[i] != arr2[i])
                {
                    break;
                }
            }
            if (arrLength == 0)
            {
                
            }
            else
            {

            }
        }
    }
}
