using System;
using System.Linq;

namespace P04_Maximal_Sum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var matrix = new long[size[0], size[1]];

            var maximalSum = long.MinValue;

            var finalRow = 0;
            var finalCol = 0;


            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => long.Parse(x))
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = elements[cols];

                    var temprorarySum = 0L;

                    if (rows > 1 && cols > 1)
                    {
                        temprorarySum = matrix[rows, cols] + matrix[rows, cols - 1] + matrix[rows, cols - 2] +
                            matrix[rows - 1, cols] + matrix[rows - 1, cols - 1] + matrix[rows - 1, cols - 2] +
                            matrix[rows - 2, cols] + matrix[rows - 2, cols - 1] + matrix[rows - 2, cols - 2];

                        if (temprorarySum > maximalSum)
                        {
                            maximalSum = temprorarySum;
                            finalRow = rows;
                            finalCol = cols;
                        }

                    }
                }
            }
            Console.WriteLine($"Sum = {maximalSum}");

            for (int i = 2; i >= 0; i--)
            {
                Console.WriteLine($"{matrix[finalRow - i, finalCol - 2]} {matrix[finalRow - i, finalCol - 1]} {matrix[finalRow - i, finalCol]}");
            }
        }
    }
}
