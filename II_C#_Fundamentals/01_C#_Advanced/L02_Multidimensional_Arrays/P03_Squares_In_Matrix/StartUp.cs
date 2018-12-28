using System;
using System.Linq;

namespace P03_Squares_In_Matrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            var matrix = new string[size[0], size[1]];

            var squaresFound = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var elements = Console.ReadLine()
                    .Split();

                matrix[rows, 0] = elements[0];

                for (int cols = 1; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = elements[cols];

                    if (rows != 0)
                    {
                        if (matrix[rows, cols] == matrix[rows - 1, cols] &&
                            matrix[rows, cols] == matrix[rows, cols - 1] &&
                            matrix[rows, cols] == matrix[rows - 1, cols - 1])
                        {
                            squaresFound++;
                        }
                    }
                }
            }

            Console.WriteLine(squaresFound);
        }
    }
}
