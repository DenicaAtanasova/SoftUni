namespace P07ExchangeVarValues
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Console.WriteLine($"Before: \r\na = {a} \r\nb = {b}");
            int oldA = 5;
            a = b;
            b = oldA;
            Console.WriteLine($"After: \r\na = {a} \r\nb = {b}");
        }
    }
}