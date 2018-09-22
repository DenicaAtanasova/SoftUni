namespace P10TriangleOfNumbers
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int col = 1; col <= n; col++)
            {
                Console.Write(col);
                for (int row = 0; row < col - 1; row++)
                {
                    Console.Write(" " + col);
                }
                Console.WriteLine();
            }
        }
    }
}
