using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console
                    .ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            int count = 0;
            int countMax = 0;
            int num = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                count = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        count++;
                    }
                    if (count > countMax)
                    {
                        countMax = count;
                        num = nums[i];
                    }
                }              
            }           
            Console.WriteLine(num);
        }
    }
}
