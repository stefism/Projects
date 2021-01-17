namespace Brickwork
{
    using System;
    using System.Linq;

    // Tha BrickSorter class handles the sorting of the bricks
    public static class BrickSorter
    {
        public static bool SortBricks(int[,] previousLayer, int[,] newLayer)
        {
            Random rnd = new Random();
            // Check if secondLayer is full
            bool isNotFull = true;
            int brickNumber = 1;
            // Count of coll delete before call row delete
            int collsIterationsCount = 0;

            // Count of overall iterations before delete all layer
            int overallIteratios = 0;

            // NumberIterations before return not found
            int stopIterations = 80_000;
            int stopIterationCounter = 0;

            // If its not full start over
            while (isNotFull)
            {
                int previousRow = 0;
                int previousColl = 0;
                bool previousIsZero = false;

                for (int row = 0; row < previousLayer.GetLength(0); row++)
                {
                    for (int coll = 0; coll < previousLayer.GetLength(1); coll++)
                    {
                        if (row != 0 || coll != 0)
                        {
                            if (newLayer[previousRow, previousColl] == 0)
                            {
                                previousIsZero = true;
                                break;
                            }
                        }

                        // Generate random positon of the brick
                        int randomBrickPosition = rnd.Next(1, 3);

                        //If its 1 try to put horisontal , if its 2 try to put vertical
                        if (randomBrickPosition == 1)
                        {
                            if (newLayer[row, coll] != 0)
                            {
                                continue;
                            }

                            if (coll + 1 < previousLayer.GetLength(1))
                            {
                                if (row + 1 < previousLayer.GetLength(0) &&
                                    previousLayer[row, coll] == previousLayer[row, coll + 1] &&
                                    newLayer[row + 1, coll] == 0)
                                {
                                    newLayer[row, coll] = brickNumber;
                                    newLayer[row + 1, coll] = brickNumber;
                                    brickNumber++;
                                    continue;
                                }
                                else if (previousLayer[row, coll] != previousLayer[row, coll + 1] &&
                                         newLayer[row, coll + 1] == 0)
                                {
                                    newLayer[row, coll] = brickNumber;
                                    newLayer[row, coll + 1] = brickNumber;
                                    brickNumber++;
                                    continue;
                                }
                            }
                            else if (row + 1 < previousLayer.GetLength(0) &&
                                     previousLayer[row, coll] != previousLayer[row + 1, coll] &&
                                     newLayer[row + 1, coll] == 0)
                            {
                                newLayer[row, coll] = brickNumber;
                                newLayer[row + 1, coll] = brickNumber;
                                brickNumber++;
                                continue;
                            }
                        }
                        else
                        {
                            if (newLayer[row, coll] != 0)
                            {
                                continue;
                            }

                            if (row + 1 < previousLayer.GetLength(0))
                            {
                                if (coll + 1 < previousLayer.GetLength(1) &&
                                    previousLayer[row, coll] == previousLayer[row + 1, coll] &&
                                    newLayer[row, coll + 1] == 0)
                                {
                                    newLayer[row, coll] = brickNumber;
                                    newLayer[row, coll + 1] = brickNumber;
                                    brickNumber++;
                                    continue;
                                }
                                else if (previousLayer[row, coll] != previousLayer[row + 1, coll] &&
                                         newLayer[row + 1, coll] == 0)
                                {
                                    newLayer[row, coll] = brickNumber;
                                    newLayer[row + 1, coll] = brickNumber;
                                    brickNumber++;
                                    continue;
                                }
                            }
                            else if (coll + 1 < previousLayer.GetLength(1) &&
                                     previousLayer[row, coll] != previousLayer[row, coll + 1] &&
                                     newLayer[row, coll + 1] == 0)
                            {
                                newLayer[row, coll] = brickNumber;
                                newLayer[row, coll + 1] = brickNumber;
                                brickNumber++;
                                continue;
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

                isNotFull = newLayer.Cast<int>().Any(x => x == 0);

                if (isNotFull)
                {
                    overallIteratios++;
                    collsIterationsCount++;
                    stopIterationCounter++;

                    if (stopIterationCounter >= stopIterations)
                    {
                        return false;
                    }

                    // if delete colls iterations are over N delete N rows
                    if (collsIterationsCount > GetSettings(previousLayer.GetLength(1), "collIterator"))
                    {
                        collsIterationsCount = 0;
                        // if delete overall iterations are over N clean wall
                        if (overallIteratios > GetSettings(previousLayer.GetLength(1), "overallIterator"))
                        {
                            CleanLayer(newLayer);
                            overallIteratios = 0;
                            brickNumber = 1;
                        }
                        brickNumber = DeleteLastNRows(newLayer);
                        continue;
                    }
                    brickNumber = DeleteLastNColls(newLayer);
                }
            }
            
            return true;
        }

        public static int DeleteLastNColls(int[,] layer)
        {
            // Get how much colls to delete for this size
            int collsToDelete = GetSettings(layer.GetLength(1), "collsToDelete");

            int rowWithNumbers = 0;
            int collWithNumbers = 0;
            bool zeroFound = false;

            // Find the first index with no brick
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

            //Delete N rows
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

        public static int DeleteLastNRows(int[,] layer)
        {
            // Get how much rows to delete for this size
            int rowsToDelete = GetSettings(layer.GetLength(1), "rowsToDelete");

            int rowsWithNumbers = 0;
            bool zeroFound = false;

            // Find the first index with no brick
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

            //Delete N collums in row bricks
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

        public static int GetSettings(int numberColls, string parameter)
        {
            switch (parameter)
            {
                case "rowsToDelete":
                    if (numberColls <= 30)
                    {
                        return 2;
                    }
                    else if (numberColls > 30 && numberColls < 60)
                    {
                        return 2;
                    }
                    else
                    {
                        return 2;
                    }
                case "collsToDelete":
                    if (numberColls <= 30)
                    {
                        return 7;
                    }
                    else if (numberColls > 30 && numberColls < 60)
                    {
                        return 20;
                    }
                    else
                    {
                        return 45;
                    }
                case "collIterator":
                    if (numberColls <= 30)
                    {
                        return 10;
                    }
                    else if (numberColls > 30 && numberColls < 60)
                    {
                        return 20;
                    }
                    else
                    {
                        return 400;
                    }
                case "overallIterator":
                    if (numberColls <= 30)
                    {
                        return 3000;
                    }
                    else if (numberColls > 30 && numberColls < 60)
                    {
                        return 12000;
                    }
                    else
                    {
                        return 30000;
                    }
            }

            return 0;
        }
    }
}

