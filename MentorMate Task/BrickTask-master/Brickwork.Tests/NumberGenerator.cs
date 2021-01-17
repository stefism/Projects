namespace Brickwork.Tests
{
    using System;
    using System.Linq;

    public static class NumberGenerator
    {
        public static int[,] Generate(int rows,int colls)
        {
            Random rnd = new Random();
            int[,] matrix = new int[rows, colls];
            int brickNumber = 1;
            var isNotFull = true;
            var iterations = 0;

            while (isNotFull)
            {
                int previousRow = 0;
                int previousColl = 0;
                bool previousIsZero = false;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int coll = 0; coll < matrix.GetLength(1); coll++)
                    {
                        if (row != 0 || coll != 0)
                        {
                            if (matrix[previousRow, previousColl] == 0)
                            {
                                previousIsZero = true;
                                break;
                            }
                        }

                        if (matrix[row, coll] != 0)
                        {
                            continue;
                        }

                        int randomBrickPosition = rnd.Next(1, 3);

                        if (randomBrickPosition == 1)
                        {
                            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, coll] == 0)
                            {
                                matrix[row, coll] = brickNumber;
                                matrix[row + 1, coll] = brickNumber;
                                brickNumber++;
                            }
                            else
                            {
                                if (coll + 1 < matrix.GetLength(1) && matrix[row, coll + 1] == 0)
                                {
                                    matrix[row, coll] = brickNumber;
                                    matrix[row, coll + 1] = brickNumber;
                                    brickNumber++;
                                }
                            }
                        }
                        else
                        {
                            if (coll + 1 < matrix.GetLength(1) && matrix[row, coll + 1] == 0)
                            {
                                matrix[row, coll] = brickNumber;
                                matrix[row, coll + 1] = brickNumber;
                                brickNumber++;
                            }
                            else
                            {
                                if (row + 1 < matrix.GetLength(0) && matrix[row + 1, coll] == 0)
                                {
                                    matrix[row, coll] = brickNumber;
                                    matrix[row + 1, coll] = brickNumber;
                                    brickNumber++;
                                }
                            }
                        }
                        previousRow = row;
                        previousColl = coll;
                    }
                    if (previousIsZero)
                    {
                        break;
                    }
                }

                iterations++;
                isNotFull = matrix.Cast<int>().Any(x => x == 0);

                if (isNotFull)
                {
                    if (iterations > 2)
                    {
                        iterations = 0;
                        CleanLayer(matrix);
                        brickNumber = 1;
                        continue;
                    }
                    brickNumber = DeleteLastNColls(matrix);
                }
            }

            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    sb.Append(rows + " ");
            //    sb.AppendLine(colls.ToString()); ;
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        sb.Append(matrix[i, j] + " ");
            //    }
            //    sb.AppendLine();
            //}

            return matrix;
        }

        private static void CleanLayer(int[,] layer)
        {
            for (int row = 0; row < layer.GetLength(0); row++)
            {
                for (int coll = 0; coll < layer.GetLength(1); coll++)
                {
                    layer[row, coll] = 0;
                }
            }
        }

        private static int DeleteLastNRows(int[,] layer)
        {
            int rowsToDelete = 3;

            int rowsWithNumbers = 0;
            bool zeroFound = false;

            for (int row = 0; row < layer.GetLength(0); row++)
            {
                for (int coll = 0; coll < layer.GetLength(1); coll++)
                {
                    if (layer[row, coll] == 0)
                    {
                        rowsWithNumbers = row;
                        zeroFound = true;
                        break;
                    }
                }
                if (zeroFound)
                {
                    break;
                }
            }

            if (rowsWithNumbers - rowsToDelete > 0)
            {
                for (int row = rowsWithNumbers - rowsToDelete; row < layer.GetLength(0); row++)
                {
                    for (int coll = 0; coll < layer.GetLength(1); coll++)
                    {
                        if (layer[row, coll] != layer[row - 1, coll])
                        {
                            layer[row, coll] = 0;
                        }
                    }
                }
            }
            else
            {
                CleanLayer(layer);
                return 1;
            }

            int higherBrickNumber = layer.Cast<int>().Max();
            return higherBrickNumber + 1;
        }

        private static int DeleteLastNColls(int[,] layer)
        {
            int collsToDelete = 3;

            int rowWithNumbers = 0;
            int collWithNumbers = 0;
            bool zeroFound = false;

            for (int row = 0; row < layer.GetLength(0); row++)
            {
                for (int coll = 0; coll < layer.GetLength(1); coll++)
                {
                    if (layer[row, coll] == 0)
                    {
                        rowWithNumbers = row;
                        collWithNumbers = coll;
                        zeroFound = true;
                        break;
                    }
                }
                if (zeroFound)
                {
                    break;
                }
            }

            for (int row = rowWithNumbers; row < layer.GetLength(0); row++)
            {
                for (int coll = collWithNumbers - collsToDelete >= 0 ? collWithNumbers - collsToDelete : 0; coll < layer.GetLength(1); coll++)
                {
                    if (rowWithNumbers > 0 && coll - 1 > 0)
                    {
                        if (layer[row, coll] != layer[row - 1, coll] && layer[row, coll] != layer[row, coll - 1])
                        {
                            layer[row, coll] = 0;
                        }
                    }
                    else
                    {
                        if (coll - 1 > 0 && layer[row, coll] != layer[row, coll - 1])
                        {
                            layer[row, coll] = 0;
                        }
                    }
                }
            }

            int higherBrickNumber = layer.Cast<int>().Max();
            return higherBrickNumber + 1;
        }
    }
}
