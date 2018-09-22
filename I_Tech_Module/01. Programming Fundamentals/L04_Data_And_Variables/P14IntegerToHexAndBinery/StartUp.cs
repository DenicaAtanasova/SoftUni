namespace P14IntegerToHexAndBinery
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numInInt = int.Parse(Console.ReadLine());
            string numInHex = numInInt.ToString("X");
            Console.WriteLine(numInHex);
            var numInBinary = Convert.ToString(numInInt, 2);
            Console.WriteLine(numInBinary);
        }
    }
}