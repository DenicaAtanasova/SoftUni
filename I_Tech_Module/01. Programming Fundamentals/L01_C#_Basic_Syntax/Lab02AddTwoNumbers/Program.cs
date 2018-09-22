namespace AddTwoNumbers
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int sum = num1 + num2;

            Console.WriteLine($"{num1} + {num2} = {sum}");
        }
    }
}