using System;
using System.Linq;

namespace L01_Sum_Matrix_Elements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var rowsColsCount = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var matrix = new int[rowsColsCount[0], rowsColsCount[1]];

            var matrixElementsSum = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var matrixElements = Console.ReadLine()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = matrixElements[cols];
                    matrixElementsSum += matrix[rows, cols];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(matrixElementsSum);
        }
    }
}
