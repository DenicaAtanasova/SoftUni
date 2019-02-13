using System;
using System.Linq;

namespace L05_Square_With_Max_Sum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var matrix = new int[size[0], size[1]];

            var sum = 0;
            var row = 0;
            var col = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var elements = Console.ReadLine()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = elements[cols];

                    if (rows > 0 && cols > 0)
                    {
                        var temprorarySum = matrix[rows, cols] + matrix[rows, cols - 1] +
                               matrix[rows - 1, cols] + matrix[rows - 1, cols - 1];

                        if (temprorarySum > sum)
                        {
                            sum = temprorarySum;
                            row = rows;
                            col = cols;
                        }
                    }
                }
            }

            Console.WriteLine($"{matrix[row - 1, col - 1]} {matrix[row - 1, col]}");
            Console.WriteLine($"{matrix[row, col - 1]} {matrix[row, col]}");
            Console.WriteLine($"{sum}");
        }
    }
}
