namespace Brickwork
{
    using Brickwork.Core.Contracts;
    using Brickwork.IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IBuilder builder;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IBuilder builder, IReader reader, IWriter writer)
        {
            this.builder = builder;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            // Get dimentions of the wall
            int[] dimentions = reader.ReadLine()
                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();

            // Wall width
            int rows = dimentions[0];

            // Wall length
            int colls = dimentions[1];

            builder.Rows = rows;
            builder.Colls = colls;
            builder.CreateBase();

            for (int i = 0; i < rows; i++)
            {
                // Read input rows
                int[] input = reader.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

                // Check the length of the input and if its valid saves the row
                if (!builder.CreateFirstLayer(input, i))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCollsCount, colls));
                }
            }

            // Validate that the length of each brick is two sectors
            builder.ValidateBricks();

            // The builder checks for a solution for a second layer
            if (builder.TryBuildNewLayer())
            {
                writer.WriteLine("");

                // Print the layer with symbols(I don`t understand the fifth point of the assessment)
                //Console.WriteLine(builder.PrintResultWithSymbols());

                // Print the new Layer
                writer.WriteLine(builder.PrintResult());
            }
            else
            {
                // If no solution exists
                writer.WriteLine("-1");
                writer.WriteLine(ExceptionMessages.NoSolution);
            }
        }
    }
}
