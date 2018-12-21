
namespace P06PrimeChecker
{
    using System;

    class StartUp
    {
        static bool isPrime(long num)
        {
            if (num <= 1)
            {
                return false;
            }
            else
            {
                for (long i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        return false;
                        break;
                    }
                }
                return true;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(isPrime(long.Parse(Console.ReadLine()))); ;
        }
    }
}