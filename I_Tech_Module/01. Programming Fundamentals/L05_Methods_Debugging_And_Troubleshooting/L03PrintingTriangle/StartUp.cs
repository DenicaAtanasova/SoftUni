
namespace L03PrintingTriangle
{
    using System;

    class StartUp
    {
        static void PrintNumsLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                PrintNumsLine(1, i);
            }
            for (int i = n - 1; i >= 1; i--)
            {
                PrintNumsLine(1, i);
            }
        }
    }
}
