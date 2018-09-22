namespace P16ComparingFloats
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double difference = 0.000001;

            if (Math.Abs(firstNumber - secondNumber) < difference)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
