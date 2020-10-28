using System;

namespace GameInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int numberOfMach = int.Parse(Console.ReadLine());
            int totalMachTime = 0;

            int extraTimeCounter = 0;
            int penaltiesCounter = 0;

            for (int i = 0; i < numberOfMach; i++)
            {
                int machTime = int.Parse(Console.ReadLine());
                totalMachTime += machTime;

                if (machTime > 120)
                {
                    penaltiesCounter++;
                }

                else if (machTime > 90)
                {
                    extraTimeCounter++;
                }

            }

            Console.Write($"{teamName} has played {totalMachTime} minutes. ");
            Console.WriteLine($"Average minutes per game: {(1.00 * totalMachTime / numberOfMach):F2}");
            Console.WriteLine($"Games with penalties: {penaltiesCounter}");
            Console.WriteLine($"Games with additional time: {extraTimeCounter}");
        }s
    }
}
