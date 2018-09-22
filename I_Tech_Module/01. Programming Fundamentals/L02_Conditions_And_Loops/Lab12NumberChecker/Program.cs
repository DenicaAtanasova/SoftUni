namespace Lab12NumberChecker
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                double num = double.Parse(Console.ReadLine());
                Console.WriteLine("It is a number.");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
