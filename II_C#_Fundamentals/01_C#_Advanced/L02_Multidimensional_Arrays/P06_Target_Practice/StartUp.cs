using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Target_Practice
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var stairDimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var stairs = new char[stairDimensions[0], stairDimensions[1]];

            var snakeElements = Console.ReadLine()
               .ToCharArray();

            var snake = new Queue<char>(snakeElements);

            ClimbStairs();

            TakeAShot();

            Print();

            void ClimbStairs()
            {
                bool moveLeftDirection = true;

                for (int row = (stairs.GetLength(0) - 1); row >= 0; row --)
                {
                    if (moveLeftDirection)
                    {
                        for (int col = (stairs.GetLength(1) - 1); col >= 0; col--)
                        {
                            stairs[row, col] = snake.Peek();
                            snake.Enqueue(snake.Dequeue());
                        }

                        moveLeftDirection = false;
                    }
                    else
                    {
                        for (int col = 0; col < stairs.GetLength(1); col++)
                        {
                            stairs[row, col] = snake.Peek();
                            snake.Enqueue(snake.Dequeue());
                        }

                        moveLeftDirection = true;
                    }
                }
            }

            void TakeAShot()
            {
                var shotParameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

                int shotRow = shotParameters[0];
                int shotCol = shotParameters[1];
                int radius = shotParameters[2];

                for (int row = 0; row < stairs.GetLength(0); row++)
                    for (int col = 0; col < stairs.GetLength(1); col++)
                    {
                        bool isWithinRange = Math.Sqrt(Math.Pow(Math.Abs(shotRow - row), 2)
                                            + Math.Pow(Math.Abs(shotCol - col), 2))
                                            <= radius;
                        if (isWithinRange)
                            stairs[row, col] = ' ';
                    }

                GetCollapsedMatrix();
            }

            void GetCollapsedMatrix()
            {
                int rows = stairs.GetLength(0);
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    string collapsedCol = "";
                    for (int row = rows - 1; row >= 0; row--)
                        if (stairs[row, col] != ' ')
                            collapsedCol += stairs[row, col];
                    for (int i = 0; i < rows; i++)
                        if (i >= collapsedCol.Length)
                            stairs[rows - 1 - i, col] = ' ';
                        else
                            stairs[rows - 1 - i, col] = collapsedCol[i];
                }
            }

            void Print()
            {
                for (int row = 0; row < stairs.GetLength(0); row++)
                {
                    for (int col = 0; col < stairs.GetLength(1); col++)
                        Console.Write(stairs[row, col]);
                    Console.WriteLine();
                }
            }
        }
    }
}
