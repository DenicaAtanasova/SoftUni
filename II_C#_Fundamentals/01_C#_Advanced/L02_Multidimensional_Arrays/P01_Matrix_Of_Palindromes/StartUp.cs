using System;
using System.Linq;

namespace P01_Matrix_Of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            var matrix = new string[size[0], size[1]];

            int firstLetterIndex = 97;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = $"{(char)(rows + firstLetterIndex)}" + $"{(char)(cols + firstLetterIndex + rows)}" + $"{(char)(rows + firstLetterIndex)}";
                }  
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
