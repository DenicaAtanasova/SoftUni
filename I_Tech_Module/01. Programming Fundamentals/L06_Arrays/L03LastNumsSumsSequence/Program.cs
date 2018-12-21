using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03LastNumsSumsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            var nums = new long[n];
            nums[0] = 1;

            for (int num = 1; num < nums.Length; num++)
            {
                long sum = 0L;

                for (int j = Math.Max(0, num - k); j <= num - 1; j++)
                {
                    sum += nums[j];
                }
                nums[num] = sum;
            }
            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
