namespace Lab7Greeting
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Hello, {firstName} {lastName}. \r\n You are {age} years old.");
        }
    }
}