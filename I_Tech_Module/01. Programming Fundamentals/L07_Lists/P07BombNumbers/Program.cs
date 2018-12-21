using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var bombArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] == bombArgs[0])
                {
                    int left = Math.Max(i - bombArgs[1], 0);

                    int right = Math.Min(i + bombArgs[1], sequence.Count - 1);

                    int lenght = right - left + 1;
                    sequence.RemoveRange(left, lenght);
                    i = 0;
                }
            }
            Console.WriteLine(sequence.Sum());
        }
    }
}
