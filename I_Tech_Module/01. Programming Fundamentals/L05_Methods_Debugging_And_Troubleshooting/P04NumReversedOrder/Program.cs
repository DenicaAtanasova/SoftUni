

namespace P04NumReversedOrder
{
    using System;

    class StartUp
    {
        static void ReverseNumDigits(string number)
        {

            for (int i = number.Length - 1; i >= 0; i--)
            {
                Console.Write(number[i]);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            ReverseNumDigits(number);
        }
    }
}