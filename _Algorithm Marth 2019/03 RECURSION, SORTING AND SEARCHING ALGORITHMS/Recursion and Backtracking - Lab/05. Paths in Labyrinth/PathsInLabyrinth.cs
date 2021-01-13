using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Paths_in_Labyrinth
{
    class PathsInLabyrinth
    {
        static char[,] labyrinth;

        static List<char> path = new List<char>();

        static void ReadLabyrinth()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            labyrinth = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = currentRow[col];
                }
            }
        }

        static void Solve(int row, int col, char direction)
        {
            if (OutsideOfLabyrinth(row, col))
            {
                return;
            }

            path.Add(direction);

            // Стигнал съм изхода
            if (IsExit(row, col))
            {
                PrintSolution();
            }
            //Ако не е изход, има още 2 варианта - 1. Стигнал съм някъде, където съм бил, 2. Стигнал съм стена.
            else if (IsPassable(row, col))
            {
                labyrinth[row, col] = 'x'; //Ако може да се стъпи на полето, го маркираме, че сме били там.

                // Пускаме с рекурсия, всички възможни посоки:
                Solve(row + 1, col, 'D'); // Надолу
                Solve(row - 1, col, 'U'); // Нагоре
                Solve(row, col + 1, 'R'); // Надясно
                Solve(row, col - 1, 'L'); // Наляво

                labyrinth[row, col] = '-'; // Отмаркираме полето (backtracking).
            }

            path.RemoveAt(path.Count -1);
        }

        private static bool IsPassable(int row, int col)
        {
            // already visited
            if (labyrinth[row, col] == 'x')
            {
                return false;
            }

            // wall
            if (labyrinth[row, col] == '*')
            {
                return false;
            }

            return true;
        }

        private static void PrintSolution()
        {
            Console.WriteLine(string.Join(string.Empty, path.Skip(1)));
        }

        private static bool IsExit(int row, int col)
        {
            return labyrinth[row, col] == 'e';
        }

        private static bool OutsideOfLabyrinth(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0))
            {
                return true;
            }

            if (col < 0 || col >= labyrinth.GetLength(1))
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            ReadLabyrinth();
            Solve(0, 0, 'S'); // Просто някаква посока. Стартирам.
        }
    }
}
