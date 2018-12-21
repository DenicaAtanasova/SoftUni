using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[] isPrime = new bool[n + 1];

            for (int i = 0; i <= n; i++)
            {
                isPrime[i] = true;
            }
            isPrime[0] = false;
            isPrime[1] = false;
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (int y = i; y <= n; y += i)
                    {
                        if (y % i == 0 && y != i)
                        {
                            isPrime[y] = false;
                        }
                    }
                }
            }

            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i] == true)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
