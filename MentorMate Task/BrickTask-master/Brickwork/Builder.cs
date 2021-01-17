namespace Brickwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // Tha Builder class handles all the operations with the wall
    public class Builder : IBuilder
    {
        // First layer
        private int[,] firstLayer;

        // Collection of the upper layers of the wall in case there are more than one layer build on top of base layer
        private List<int[,]> upperLayers;

        // Wall width
        private int rows;

        // Wall length
        private int colls;

        public Builder()
        {
            this.firstLayer = new int[rows, colls];
            this.upperLayers = new List<int[,]>();
        }

        // Property for width that validates dimention value
        public int Rows
        {
            get => this.rows;
            set
            {
                if (value % 2 != 0)
                {
                    throw new ArgumentException(ExceptionMessages.DimentionNotEven);
                }
                if (value > 100 || value < 2)
                {
                    throw new ArgumentException(ExceptionMessages.DimentionOutOfRange);
                }
                this.rows = value;
            }
        }

        // Property for length that validates dimention value
        public int Colls
        {
            get => this.colls;
            set
            {
                if (value % 2 != 0)
                {
                    throw new ArgumentException(ExceptionMessages.DimentionNotEven);
                }
                if (value > 100 || value < 2)
                {
                    throw new ArgumentException(ExceptionMessages.DimentionOutOfRange);
                }
                this.colls = value;
            }
        }

        public void CreateBase()
        {
            this.firstLayer = new int[this.rows, this.colls];
        }

        // Creating base layer
        public bool CreateFirstLayer(int[] input, int row)
        {
            // Check if the length is more than allowed
            if (input.Length != this.Colls)
            {
                return false;
            }

            // If valid add collums in the base layer
            for (int coll = 0; coll < firstLayer.GetLength(1); coll++)
            {
                firstLayer[row, coll] = input[coll];
            }

            return true;
        }

        // Check for a soluton for second layer
        public bool TryBuildNewLayer()
        {
            // Instance for the new layer
            int[,] newLayer = new int[this.Rows, this.Colls];

            //Check if this is the first layer on top of base layer.If not - takes the last layer.
            int[,] previousLayer = GetLastLayer();

            // Check for a solution for new layer with BrickSorter static class and if any - adds it to the collection
            if (BrickSorter.SortBricks(previousLayer, newLayer))
            {
                this.upperLayers.Add(newLayer);
                return true;
            }

            return false;
        }

        // Get last layer on the wall
        public int[,] GetLastLayer()
        {
            if (this.upperLayers.Count() == 0)
            {
                return this.firstLayer;
            }
            else
            {
                return this.upperLayers[this.upperLayers.Count() - 1];
            }
        }

        // Validate if all the bricks are with the correct length
        public void ValidateBricks()
        {
            // Cast the multidimentional array into one single array
            var baseLayerBricks = this.firstLayer.Cast<int>();

            // Checks the length
            var count = baseLayerBricks
                        .GroupBy(e => e)
                        .Where(e => e.Count() < 2 || e.Count() > 2)
                        .Select(e => e.First());

            if (count.Any())
            {
                throw new ArgumentException(ExceptionMessages.InvalidBrickSize);
            }
        }

        // Print the results with symbols.I did not fully understand the fifth point of the assessment.
        public string PrintResultWithSymbols()
        {
            var sb = new StringBuilder();
            List<List<string>> forPrinting = new List<List<string>>();

            var lastLayer = GetLastLayer();

            var counter = 0;
            for (int i = 0; i < lastLayer.GetLength(0) * 2; i += 2)
            {
                forPrinting.Add(new List<string>());
                forPrinting.Add(new List<string>());

                int previous = 0;
                for (int j = 0; j < lastLayer.GetLength(1); j++)
                {
                    if (previous != lastLayer[counter, j] && previous != 0)
                    {
                        forPrinting[i].Add("/" + lastLayer[counter, j]);
                    }
                    else
                    {
                        forPrinting[i].Add(" " + lastLayer[counter, j].ToString());
                    }
                    previous = lastLayer[counter, j];
                }

                counter++;
            }

            forPrinting.RemoveAt(forPrinting.Count - 1);

            counter = 0;
            for (int i = 1; i < forPrinting.Count(); i += 2)
            {
                for (int j = 0; j < this.colls; j++)
                {
                    if (lastLayer[counter,j] == lastLayer[counter+1, j])
                    {
                        forPrinting[i].Add("  ");
                    }
                    else
                    {
                        forPrinting[i].Add("--");
                    }
                }
                counter++;
            }

            for (int i = 0; i < forPrinting.Count(); i++)
            {
                for (int j = 0; j < forPrinting[i].Count(); j++)
                {
                    sb.Append(forPrinting[i][j]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        // Print only the numeric result
        public string PrintResult()
        {
            var sb = new StringBuilder();
            var lastLayer = GetLastLayer();

            for (int i = 0; i < lastLayer.GetLength(0); i++)
            {
                for (int j = 0; j < lastLayer.GetLength(1); j++)
                {
                    sb.Append(lastLayer[i, j] + " ");
                }
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd(); ;
        }
    }
}
