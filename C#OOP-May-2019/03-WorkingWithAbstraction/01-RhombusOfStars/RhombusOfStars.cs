using System;

namespace _01_RhombusOfStars
{
    class RhombusOfStars
    {
        static void Main(string[] args)
        {
            int rhombusSize = int.Parse(Console.ReadLine());

            for (int starsToPrint = 1; starsToPrint <= rhombusSize; starsToPrint++)
            {
                PrintRow(rhombusSize, starsToPrint);
            }

            for (int starsToPrint = rhombusSize - 1; starsToPrint > 0; starsToPrint--)
            {
                PrintRow(rhombusSize, starsToPrint);
            }
        }

        static void PrintRow(int rhombusSize, int starsToPrint)
        {
            for (int i = 0; i < rhombusSize - starsToPrint; i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < starsToPrint; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}
