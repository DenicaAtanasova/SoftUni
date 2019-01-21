using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Bombs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            var bombs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet();

            foreach (var bomb in bombs)
            {
                var bombArgs = bomb
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var bombRow = bombArgs[0];
                var bombCol = bombArgs[1];

                var bombDamage = matrix[bombRow, bombCol];

                if (bombDamage <= 0)
                {
                    continue;
                }

                for (int row = Math.Max(0, bombRow - 1); row < Math.Min(bombRow + 2, matrix.GetLength(0)); row++)
                {
                    for (int col = Math.Max(0, bombCol - 1); col < Math.Min(bombCol + 2, matrix.GetLength(1)); col++)
                    {
                        if (matrix[row, col] > 0)
                            matrix[row, col] -= bombDamage;
                    }
                }
            }

            var cellsAlive = new List<int>();

            var result = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        cellsAlive.Add(matrix[row, col]);
                    }
                    result.Append(matrix[row, col] + " ");
                }
                if (row != matrix.GetLength(0) - 1)
                {
                    result.Append(Environment.NewLine);
                }
            }

            Console.WriteLine($"Alive cells: {cellsAlive.Count}");
            Console.WriteLine($"Sum: {cellsAlive.Sum()}");
            Console.WriteLine(result);
        }
    }
}