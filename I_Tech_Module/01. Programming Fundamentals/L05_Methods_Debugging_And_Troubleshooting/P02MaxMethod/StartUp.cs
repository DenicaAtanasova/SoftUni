
namespace P02MaxMethod
{
    using System;

    class StartUp
    {
        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        static void Main(string[] args)
        {
            int maxNum = GetMax(int.Parse(Console.ReadLine()), GetMax(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
            Console.WriteLine(maxNum);
        }
    }
}
