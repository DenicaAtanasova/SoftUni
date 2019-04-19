using System;

namespace _02_Throne_Conquering
{
    class Program
    {
        static void Main(string[] args)
        {
            var parisEnergy = int.Parse(Console.ReadLine());
            var size = int.Parse(Console.ReadLine());
            var parisPosition = (row: -1, col: -1);
            var parisReachedThrone = false;
            var field = new char[size][];

            for (int row = 0; row < size; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();
                int position = Array.IndexOf(field[row], 'P');

                if (position > -1)
                {
                    field[row][position] = '-';
                    parisPosition.row = row;
                    parisPosition.col = position;
                }
            }

            while (parisEnergy > 0 && !parisReachedThrone)
            {
                var commandLine = Console.ReadLine().Split();
                var direction = commandLine[0];

                var enemyRow = int.Parse(commandLine[1]);
                var enemyCol = int.Parse(commandLine[2]);

                EnemySpawn(enemyRow, enemyCol);
                ParisTryMove(direction);

                if (field[parisPosition.row][parisPosition.col] == 'H')
                {
                    field[parisPosition.row][parisPosition.col] = '-';
                    parisReachedThrone = true;
                    break;
                }

                if (field[parisPosition.row][parisPosition.col] == 'S')
                {
                    parisEnergy -= 2;
                    field[parisPosition.row][parisPosition.col] = '-';
                }

                if (parisEnergy <= 0)
                {
                    field[parisPosition.row][parisPosition.col] = 'X';
                }
            }

            if (parisReachedThrone)
            {
                Console.WriteLine($"Paris has successfully sat on the throne! Energy left: {parisEnergy}");
                printField();
            }
            else
            {
                Console.WriteLine($"Paris died at {parisPosition.row};{parisPosition.col}.");
                printField();
            }

            void EnemySpawn(int row, int col)
            {
                field[row][col] = 'S';
            }

            void ParisTryMove(string command)
            {
                switch (command)
                {
                    case "up":
                        if (parisPosition.row > 0)
                        {
                            parisPosition.row--;
                        }
                        break;
                    case "down":
                        if (parisPosition.row < size - 1)
                        {
                            parisPosition.row++;
                        }
                        break;
                    case "left":
                        if (parisPosition.col > 0)
                        {
                            parisPosition.col--;
                        }
                        break;
                    case "right":
                        if (parisPosition.col < size - 1)
                        {
                            parisPosition.col++;
                        }
                        break;
                }

                parisEnergy -= 1;
            }

            void printField()
            {
                foreach (var row in field)
                {
                    Console.WriteLine(string.Join("", row));
                }
            }
        }
    }
}
