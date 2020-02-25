using System;

namespace CodingV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string numberAsString = "" + n;

            int rows = numberAsString.Length;

            for (int i = 0; i < rows; i++) // Колко реда искаме
            {
                int number = int.Parse(numberAsString[numberAsString.Length - 1 - i] + "");

                if (number == 0)
                {
                    Console.WriteLine("ZERO");
                    continue;
                }

                char symbolToRepeat = (char)(number + 33);

                for (int j = 0; j < number; j++)
                {
                    Console.WriteLine(symbolToRepeat);
                }
                Console.WriteLine();
            }
        }
    }
}
