using System.Collections.Generic;
using System.Linq;

namespace GreenVsRed
{
    public class MatrixField
    {
        private int _matrixRows;
        private int _matrixCols;
        private List<Cell> _matrix = new List<Cell>();
        private List<Coordinate> _coordinatesForUpdate = new List<Coordinate>();

        public MatrixField(Coordinate matrixSize)
        {
            _matrixRows = matrixSize.CoordinateX;
            _matrixCols = matrixSize.CoordinateY;
        }

        public Coordinate TargetCellCoordinates { get; set; }

        public int TrackCellCounter { get; set; }

        public void AddCell(Cell cell)
        {
            _matrix.Add(cell);
        }

        public void AddCoordinateForUpdate(Coordinate coordinates)
        {
            _coordinatesForUpdate.Add(coordinates);
        }

        public void UpdateCells()
        {
            foreach (var coordinates in _coordinatesForUpdate)
            {
                var currentCell = GetCell(coordinates.CoordinateX, coordinates.CoordinateY);

                currentCell.Value = currentCell.Value == 0 ? 1 : 0;
            }
        }

        public void ClearCoordinates()
        {
            _coordinatesForUpdate = new List<Coordinate>();
        }

        public int GetGreenCellNumber(Coordinate coordinates)
        {
            int greenCount = 0;

            int row = coordinates.CoordinateX;
            int col = coordinates.CoordinateY;

            var currentCell = GetCell(row, col);

            Cell cell;

            if (row > 0)
            {
                cell = GetCell(row - 1, col);
                FillCounters(ref greenCount, cell.Value);
            }

            if (row < _matrixRows - 1)
            {
                cell = GetCell(row + 1, col);
                FillCounters(ref greenCount, cell.Value);
            }

            if (col > 0)
            {
                cell = GetCell(row, col - 1);
                FillCounters(ref greenCount, cell.Value);
            }

            if (col < _matrixCols - 1)
            {
                cell = GetCell(row, col + 1);
                FillCounters(ref greenCount, cell.Value);
            }

            if (col > 0 && row > 0)
            {
                cell = GetCell(row - 1, col - 1);
                FillCounters(ref greenCount, cell.Value);
            }

            if (row > 0 && col < _matrixCols - 1)
            {
                cell = GetCell(row - 1, col + 1);
                FillCounters(ref greenCount, cell.Value);
            }

            if (col > 0 && row < _matrixRows - 1)
            {
                cell = GetCell(row + 1, col - 1);
                FillCounters(ref greenCount, cell.Value);
            }

            if (row < _matrixRows - 1 && col < _matrixCols - 1)
            {
                cell = GetCell(row + 1, col + 1);
                FillCounters(ref greenCount, cell.Value);
            }

            return greenCount;
        }

        public void UpdateTrackCell()
        {
            var targetCell = _matrix.FirstOrDefault(x => x.Coordinates.CoordinateX == TargetCellCoordinates.CoordinateX && x.Coordinates.CoordinateY == TargetCellCoordinates.CoordinateY);

            if (targetCell.Value == 1)
            {
                TrackCellCounter++;
            }
        }

        public Cell GetCell(int row, int col)
        {
            return _matrix.FirstOrDefault(x => x.Coordinates.CoordinateX == row && x.Coordinates.CoordinateY == col);
        }

        private static void FillCounters(ref int greenCount, int cellValue)
        {
            if (cellValue == 1)
            {
                greenCount++;
            }
        }
    }
}
