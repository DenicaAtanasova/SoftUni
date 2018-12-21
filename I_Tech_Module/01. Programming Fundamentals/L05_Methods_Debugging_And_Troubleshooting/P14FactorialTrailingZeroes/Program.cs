using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P14FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorialNum = GetFactorial(n);
            BigInteger lastDigit = 0;
            int count = 0;
            while (lastDigit == 0)
            {
                lastDigit = factorialNum % 10;
                factorialNum /= 10;
                if (lastDigit == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        private static BigInteger GetFactorial(int n)
        {
            BigInteger sum = 1;
            for (int i = 1; i <= n; i++)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
