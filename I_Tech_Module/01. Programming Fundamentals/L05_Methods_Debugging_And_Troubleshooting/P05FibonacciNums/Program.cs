using System;

namespace P05FibonacciNums
{
    using System;

    class Program
    {
        static int Fib(int num)
        {
            int addNum = 1;
            int fibNum = 1;
            for (int i = 0; i < num - 1; i++)
            {
                int sum = addNum + fibNum;
                addNum = fibNum;
                fibNum = sum;
            }
                return fibNum;
        }

        static void Main(string[] args)
        {         
            Console.WriteLine(Fib(int.Parse(Console.ReadLine())));
        }
    }
}
