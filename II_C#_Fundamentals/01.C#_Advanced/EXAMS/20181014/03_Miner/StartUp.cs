using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Miner
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var routeEndPosition = (row: -1, col: -1);
            var minerPosition = (row: -1, col: -1);
            var totalCoals = 0;

            var fieldSize = int.Parse(Console.ReadLine());
            var field = new string[fieldSize, fieldSize];
            var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < fieldSize; row++)
            {
                var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = line[col];

                    if(line[col] == "s")
                    {
                        minerPosition.row = row;
                        minerPosition.col = col;
                    }

                    if(line[col] == "e")
                    {
                        routeEndPosition.row = row;
                        routeEndPosition.col = col;
                    }

                    if(line[col] == "c")
                    {
                        totalCoals++;
                    }
                }
            }

            
            Dig();

            void Dig()
            {
                var result = string.Empty;

                foreach (var command in commands)
                {
                    TryMove(command);

                    if(minerPosition.row == routeEndPosition.row &&
                       minerPosition.col == routeEndPosition.col)
                    {
                        result = $"Game over! ({minerPosition.row}, {minerPosition.col})";
                        break;
                    }
                    else if (field[minerPosition.row, minerPosition.col] == "c")
                    {
                        field[minerPosition.row, minerPosition.col] = "*";
                        totalCoals--;
                    }

                    if (totalCoals == 0)
                    {
                        result = $"You collected all coals! ({minerPosition.row}, {minerPosition.col})";
                        break;
                    }
                }

                if (string.IsNullOrEmpty(result))
                {
                    result = $"{totalCoals} coals left. ({minerPosition.row}, {minerPosition.col})";
                }

                Console.WriteLine(result);
            }

            void TryMove(string command)
            {
                switch (command)
                {
                    case "up":
                        if (minerPosition.row > 0)
                        {
                            minerPosition.row--;
                        }
                        break;
                    case "down":
                        if(minerPosition.row < fieldSize - 1)
                        {
                            minerPosition.row++;
                        }
                        break;
                    case "left":
                        if(minerPosition.col > 0)
                        {
                            minerPosition.col--;
                        }
                        break;
                    case "right":
                        if (minerPosition.col < fieldSize - 1)
                        {
                            minerPosition.col++;
                        }
                        break;
                }
            }
        }
    }
}
