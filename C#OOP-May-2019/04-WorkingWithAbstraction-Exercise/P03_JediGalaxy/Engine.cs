using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class Engine
    {
        private int[,] matrix;
        private long totalSum;

        public void Run()
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            int rows = dimensions[0];
            int cols = dimensions[1];

            InitializeMatrix(rows, cols);

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int[] evilCoordinates = Console.ReadLine().Split(new string[] { " " },
                    StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];

                MoveEvilToTopLeftCorner(evilRow, evilCol);

                int playerRow = playerCoordinates[0];
                int playerCol = playerCoordinates[1];

                MovePlayerToTopRightCorner(playerRow,  playerCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
        }

        private void MovePlayerToTopRightCorner(int playerRow, int playerCol)
        {
            while (playerRow >= 0 && playerCol < matrix.GetLength(1))
            {
                if (IsInside(playerRow, playerCol))
                {
                    totalSum += matrix[playerRow, playerCol];
                }

                playerCol++;
                playerRow--;
            }
        }

        private void MoveEvilToTopLeftCorner(int evilRow, int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (IsInside(evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private bool IsInside(int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < matrix.GetLength(0)
                        && targetCol >= 0 && targetCol < matrix.GetLength(1);
        }

        private void InitializeMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];

            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }
    }
}
