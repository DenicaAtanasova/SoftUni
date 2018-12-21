using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07PrimesInGivenRange
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            CheckRangeForPrimes(startNum, endNum);
        }
        static void CheckRangeForPrimes(int startNum, int endNum)
        {
            List<int> primeNums = new List<int>();
            if (startNum > endNum)
            {
                Console.WriteLine("(empty list)");
                return;
            }
            if (startNum <= 1 || endNum < 0)
            {
                startNum = 2;
            }
            for (int i = startNum; i <= endNum; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeNums.Add(i);
                }
            }
            Print(primeNums);
        }
        static void Print(List<int> primeNums)
        {
            Console.WriteLine(String.Join(", ", primeNums));
        }
    }
}
