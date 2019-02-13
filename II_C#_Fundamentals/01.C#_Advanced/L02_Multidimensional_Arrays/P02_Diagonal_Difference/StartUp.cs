using System;
using System.Linq;

namespace P02_Diagonal_Difference
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new long[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            //Primary diagonal:
            var primarySum = 0L;

            for (int row = 0; row < n; row++)
            {
                primarySum += matrix[row][row];
            }

            //Secondary diagonal:
            var secondarySum = 0L;

            for (int row = 0, col = n - 1; row < n; row++, col--)
            {
                secondarySum += matrix[row][col];
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
