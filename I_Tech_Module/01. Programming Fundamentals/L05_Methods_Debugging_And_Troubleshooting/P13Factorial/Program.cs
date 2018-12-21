using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P13Factorial
{
    class Program
    {      
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            GetFactorial(n);
        }

        private static void GetFactorial(int n)
        {
            BigInteger sum = 1;
            for (int i = 1; i <= n; i++)
            {
                sum *= i;
            }
            Console.WriteLine(sum);
        }
    }
}
