namespace P04VariableInHexFormat
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var hexadecimalNumber = Console.ReadLine();
            int decimalNumber = Convert.ToInt32(hexadecimalNumber, 16);

            Console.WriteLine(decimalNumber);
        }
    }
}
