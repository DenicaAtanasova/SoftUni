namespace P13VowelOrDigit
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var symbol = Console.ReadLine();
            try
            {
                int digit = int.Parse(symbol);
                Console.WriteLine("digit");
            }
            catch (Exception)
            {
                if (symbol == "a" || symbol == "o" || symbol == "u" || symbol == "e" || symbol == "i")
                {
                    Console.WriteLine("vowel");
                }
                else
                {
                    Console.WriteLine("other");
                }
            }
        }
    }
}
