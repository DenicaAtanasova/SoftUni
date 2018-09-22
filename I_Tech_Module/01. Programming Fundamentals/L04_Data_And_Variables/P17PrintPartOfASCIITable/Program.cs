namespace P17PrintPartOfASCIITable
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            for (int i = firstNum; i <= secondNum; i++)
            {
                char asciiSymbol = (char)i;
                Console.Write(asciiSymbol + " ");
            }
            Console.WriteLine();
        }
    }
}
