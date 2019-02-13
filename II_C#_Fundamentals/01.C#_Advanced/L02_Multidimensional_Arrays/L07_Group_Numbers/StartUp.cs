using System;
using System.Linq;

namespace L07_Group_Numbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.None)
            .Select(int.Parse).ToArray();

            int[] counter = new int[3];

            foreach (var number in numbers)
            {
                counter[Math.Abs(number % 3)]++;
            }

            int[][] groupedNums = new int[3][];
            for (int i = 0; i < counter.Length; i++)
            {
                groupedNums[i] = new int[counter[i]];
            }

            int[] index = new int[3];
            foreach (var number in numbers)
            {
                int reminder = Math.Abs(number % 3);
                groupedNums[reminder][index[reminder]] = number;
                index[reminder]++;
            }

            Console.WriteLine(string.Join(" ", groupedNums[0]));
            Console.WriteLine(string.Join(" ", groupedNums[1]));
            Console.WriteLine(string.Join(" ", groupedNums[2]));
        }
    }
}
