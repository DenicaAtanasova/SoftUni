using System;

namespace L08_Pascal_Triangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var pascalTriangle = new long[size][];

            pascalTriangle[0] = new long[1];
            pascalTriangle[0][0] = 1;

            for (int rows = 1; rows < size; rows++)
            {
                pascalTriangle[rows] = new long[rows + 1];

                pascalTriangle[rows][0] = 1;

                var length = pascalTriangle[rows].Length;

                for (int cols = 1; cols < rows; cols++)
                {
                    pascalTriangle[rows][cols] = pascalTriangle[rows - 1][cols - 1] + pascalTriangle[rows - 1][cols];
                }

                pascalTriangle[rows][length - 1] = pascalTriangle[rows - 1][length - 2];
            }

            foreach (var nums in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
