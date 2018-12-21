using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P02ConvertToBase10
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseConverter(Console.ReadLine());
        }
        static void BaseConverter(string s)
        {
            string[] numberAndBase = s.Split();
            int numberBase = int.Parse(numberAndBase[0]);
            var numberToConvert = numberAndBase[1].ToString().Reverse().ToArray();

            BigInteger sum = 0;

            for (int i = 0; i < numberAndBase[1].Length; i++)
            {
                sum += int.Parse(numberToConvert[i].ToString()) * BigInteger.Pow(numberBase, i);
            }
            Console.WriteLine(sum);
        }
    }
}
