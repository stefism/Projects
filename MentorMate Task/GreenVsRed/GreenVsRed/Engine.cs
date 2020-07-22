using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenVsRed
{
    public class Engine
    {
        private int[,] matrix;

        private int matrixRow;

        private int matrixCol;

        private int[] trackCell;

        private int rotation;

        private int trackCellCounter = 0;

        private List<int []> cellToChange = new List<int[]>();

        public void Run()
        {
            Console.Write("Matrix size: ");
            int[] matrixSize = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            matrixRow = matrixSize[1];
            matrixCol = matrixSize[0];

            matrix = new int[matrixRow, matrixCol];

            Console.WriteLine("Insert matrix state:");
            FillMatrix();

            Console.WriteLine("Insert track cell and generation:");

            int[] cellAndGeneration = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            trackCell = new int[]{ cellAndGeneration[1], cellAndGeneration[0]};

            if (matrix[trackCell[0], trackCell[1]] == 1)
            {
                trackCellCounter++;
            }

            rotation = cellAndGeneration[2];

            while (rotation >= 0)
            {
                cellToChange = new List<int[]>();
                
                PrepareCellToChange();

                int currentTrackCellState = matrix[trackCell[0], trackCell[1]];

                int cellStateAfterChange = matrix[trackCell[0], trackCell[1]];

                if (cellStateAfterChange == 1)
                {
                    trackCellCounter++;
                }

                foreach (var cell in cellToChange)
                {
                    if (matrix[cell[0], cell[1]] == 0)
                    {
                        matrix[cell[0], cell[1]] = 1;
                    }

                    else
                    {
                        matrix[cell[0], cell[1]] = 0;
                    }                    
                }

                rotation--;
            }

            Console.WriteLine($"# expected result: {trackCellCounter}");

            //Green - 1, Red - 0            
        }

        private void PrepareCellToChange()
        {
            for (int row = 0; row < matrixRow; row++)
            {
                for (int col = 0; col < matrixCol; col++)
                {
                    int[] counters = CalculateCellChange(row, col);

                    int redCounter = counters[0];
                    int greenCounter = counters[1];

                    int currentCell = matrix[row, col];

                    if (currentCell == 1) //Green
                    {
                        int[] numberToChange = { 0, 1, 4, 5, 7, 8 };

                        if (numberToChange.Contains(greenCounter))
                        // Change if green = 0, 1, 4, 5, 7 or 8
                        {
                            cellToChange.Add(new int[] { row, col });
                        }
                    }
                    else //Red
                    {
                        if (greenCounter == 3 || greenCounter == 6)
                        // Change if green = 3 or 6
                        {
                            cellToChange.Add(new int[] { row, col });
                        }
                    }
                }
            }
        }

        private int[] CalculateCellChange(int row, int col)
        {
            int redCount = 0;
            int greenCount = 0;

            int currentCell = matrix[row, col];
            int cell;

            if (row > 0)
            {
                cell = matrix[row - 1, col];
                FillCounters(ref redCount, ref greenCount, cell);
            }

            if (row < matrixRow - 1)
            {
                cell = matrix[row + 1, col];
                FillCounters(ref redCount, ref greenCount, cell);
            }

            if (col > 0)
            {
                cell = matrix[row, col - 1];
                FillCounters(ref redCount, ref greenCount, cell);
            }

            if (col < matrixCol - 1)
            {
                cell = matrix[row, col + 1];
                FillCounters(ref redCount, ref greenCount, cell);
            }

            if (col > 0 && row > 0)
            {
                cell = matrix[row - 1, col - 1];
                FillCounters(ref redCount, ref greenCount, cell);
            }

            if (row > 0 && col < matrixCol - 1)
            {
                cell = matrix[row - 1, col + 1];
                FillCounters(ref redCount, ref greenCount, cell);
            }

            if (col > 0 && row < matrixRow - 1)
            {
                cell = matrix[row + 1, col - 1];
                FillCounters(ref redCount, ref greenCount, cell);
            }

            if (row < matrixRow - 1 && col < matrixCol - 1)
            {
                cell = matrix[row + 1, col + 1];
                FillCounters(ref redCount, ref greenCount, cell);
            }

            int[] output = { redCount, greenCount };
            
            return output;
        }

        private static void FillCounters(ref int redCount, ref int greenCount, int cell)
        {
            if (cell == 0)
            {
                redCount++;
            }
            else
            {
                greenCount++;
            }
        }

        private void FillMatrix()
        {
            for (int row = 0; row < matrixRow; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrixCol; col++)
                {
                    string currentNumber = input[col].ToString();

                    matrix[row, col] = int.Parse(currentNumber);
                }
            }
        }
    }
}
