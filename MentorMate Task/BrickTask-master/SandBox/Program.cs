namespace SandBox
{
    using Brickwork.Tests;
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            // Take dimentions from console and create base layer
            int[] dimentions = Console.ReadLine()
                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();

            int[,] wall = NumberGenerator.Generate(dimentions[0], dimentions[1]);

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int coll = 0; coll < wall.GetLength(1); coll++)
                {
                    Console.Write(wall[row,coll]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
