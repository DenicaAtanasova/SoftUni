﻿namespace Task1DebitCardNumber
{
    using System;

    public class StratUp
    {
        public static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int num4 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{num1:D4} {num2:D4} {num3:D4} {num4:D4}");
        }
    }
}
