using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace P01ConvertBases
{
    class Program
    {
        static void BaseConverter(string s)
        {
            string[] numberAndBase = s.Split().ToArray();
            int numberBase = int.Parse(numberAndBase[0]);
            BigInteger numberToConvert = BigInteger.Parse(numberAndBase[1]);

            List<BigInteger> nums = new List<BigInteger>();

            while (numberToConvert > 0)
            {
                var reminder = numberToConvert % numberBase;
                numberToConvert /= numberBase;
                nums.Add(reminder);
            }
            nums.Reverse();
            Console.WriteLine(String.Join("", nums));
        }
        static void Main(string[] args)
        {
            BaseConverter(Console.ReadLine());
        }
    }
}