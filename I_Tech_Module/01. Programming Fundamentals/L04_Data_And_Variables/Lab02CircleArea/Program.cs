﻿namespace Lab2CircleArea
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            double area = Math.PI * Math.Pow(radius, 2);
            Console.WriteLine("{0:F12}", area);
        }
    }
}
