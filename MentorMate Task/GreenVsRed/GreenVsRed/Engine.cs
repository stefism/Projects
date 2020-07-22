using System;
using System.Linq;

namespace GreenVsRed
{
    public class Engine
    {
        private MatrixField _matrix;
        private Coordinate _matrixCoordinates;

        public void Run()
        {
            Console.Write("Matrix size: ");
            int[] matrixSize = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            _matrixCoordinates = new Coordinate(matrixSize[1], matrixSize[0]);

            _matrix = new MatrixField(_matrixCoordinates);

            Console.WriteLine("Insert matrix state:");
            FillMatrix();

            Console.WriteLine("Insert track cell and generation:");

            int[] cellAndGeneration = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            _matrix.TargetCellCoordinates = new Coordinate(cellAndGeneration[1], cellAndGeneration[0]);

            var rotation = cellAndGeneration[2];

            while (rotation >= 0)
            {
                _matrix.ClearCoordinates();

                PrepareCellToChange();

                _matrix.UpdateTrackCell();

                _matrix.UpdateCells();

                rotation--;
            }

            Console.WriteLine($"# expected result: {_matrix.TrackCellCounter}");

            //Green - 1, Red - 0            
        }

        private void PrepareCellToChange()
        {
            for (int row = 0; row < _matrixCoordinates.CoordinateX; row++)
            {
                for (int col = 0; col < _matrixCoordinates.CoordinateY; col++)
                {
                    Coordinate coordinate = new Coordinate(row, col);

                    int greenCounter = _matrix.GetGreenCellNumber(coordinate);

                    int currentCell = _matrix.GetCell(row, col).Value;

                    if (currentCell == 1) //Green
                    {
                        int[] numberToChange = { 0, 1, 4, 5, 7, 8 };

                        if (numberToChange.Contains(greenCounter))
                        // Change if green = 0, 1, 4, 5, 7 or 8
                        {
                            _matrix.AddCoordinateForUpdate(new Coordinate(row, col));
                        }
                    }
                    else //Red
                    {
                        if (greenCounter == 3 || greenCounter == 6)
                        // Change if green = 3 or 6
                        {
                            _matrix.AddCoordinateForUpdate(new Coordinate(row, col));
                        }
                    }
                }
            }
        }

        private void FillMatrix()
        {
            for (int row = 0; row < _matrixCoordinates.CoordinateX; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < _matrixCoordinates.CoordinateY; col++)
                {
                    string currentNumber = input[col].ToString();
                    Cell cell = new Cell();
                    cell.Coordinates = new Coordinate(row, col);
                    cell.Value = int.Parse(currentNumber);
                    _matrix.AddCell(cell);
                }
            }
        }
    }
}
