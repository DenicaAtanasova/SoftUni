using System;
using System.Linq;

namespace P07_Lego_Blocks
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var cellsCounter = new int[n];

            var firstBlock = ArrangeBlock(1, n);
            var secondBlock = ArrangeBlock(2, n);

            FitBlocks();

            string[][] ArrangeBlock(int arrayNumber, int rows)
            {
                var block = new string[rows][];

                for (int row = 0; row < rows; row++)
                {
                    block[row] = GetInput(arrayNumber);

                    cellsCounter[row] += block[row].Length;
                }

                return block;
            }

            void FitBlocks()
            {
                var doBlocksFit = true;

                for (int i = 1; i < n; i++)
                {
                    if (cellsCounter[i] != cellsCounter[i - 1])
                    {
                        doBlocksFit = false;
                    }

                }

                if (doBlocksFit)
                {
                    for (int row = 0; row < n; row++)
                    {
                        Console.WriteLine("[{0}]", string.Join(", ",
                                                    string.Join(", ", firstBlock[row]),
                                                    string.Join(", ", secondBlock[row])));
                    }
                }
                else
                {
                    var cellsCount = cellsCounter.Sum();
                    Console.WriteLine($"The total number of cells is: {cellsCount}");
                }
            }
        }

        private static string[] GetInput(int arrayNumber)
        {
            var input = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (arrayNumber == 2)
            {
                Array.Reverse(input);

                return input;
            }

            return input;
        }
    }
}
