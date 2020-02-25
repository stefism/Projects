using System;

namespace DivideWithoutRemainder_Delenie_bez_ost
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            double counterFor2 = 0;
            double counterFor3 = 0;
            double counterFor4 = 0;

            for (int i = 0; i < numbers; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    counterFor2++;
                }

                if (number % 3 == 0)
                {
                    counterFor3++;
                }

                if (number % 4 == 0)
                {
                    counterFor4++;
                }
            }

            double percentFor2 = counterFor2 / numbers * 100;
            double percentFor3 = counterFor3 / numbers * 100;
            double percentFor4 = counterFor4 / numbers * 100;

            Console.WriteLine($"{(percentFor2):F2}%");
            Console.WriteLine($"{(percentFor3):F2}%");
            Console.WriteLine($"{(percentFor4):F2}%");
        }
    }
}
