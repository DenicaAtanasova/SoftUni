using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03FoldAndSum
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

            int k = arr.Length / 4;

            int[] leftArr = arr.Take(k).ToArray();         
            int[] midArr = arr.Skip(k).Take(2 * k).ToArray();
            int[] rightArr = arr.Skip(3 * k).Take(k).ToArray();

            Array.Reverse(leftArr);
            Array.Reverse(rightArr);

            var sumArr = leftArr.Concat(rightArr).ToArray();
            for (int i = 0; i < 2 * k; i++)
            {
                sumArr[i] += midArr[i];
            }

            Console.WriteLine(String.Join(" ", sumArr));
        }
    }
}
