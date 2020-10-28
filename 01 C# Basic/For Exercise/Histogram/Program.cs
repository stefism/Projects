using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            int numbersTo200 = 0;
            int numbersFrom200To399 = 0;
            int numbersFrom400To599 = 0;
            int numbersFrom600To799 = 0;
            int numbersFrom800 = 0;
            int totalNumbers = 0;

            for (int i = 0; i < numbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                totalNumbers++;

                if (number < 200)
                {
                    numbersTo200++;
                }

                else if (number >= 200 && number <= 399)
                {
                    numbersFrom200To399++;
                }

                else if (number >= 400 && number <= 599)
                {
                    numbersFrom400To599++;
                }

                else if (number >= 600 && number <= 799)
                {
                    numbersFrom600To799++;
                }

                else if (number > 800)
                {
                    numbersFrom800 ++;
                }
            }

            double percentNumbersTo200 = numbersTo200 / totalNumbers * 100;
            double percentNumbersFrom200To399 = numbersFrom200To399 / totalNumbers * 100;
            double percentNumbersFrom400To599 = numbersFrom400To599 / totalNumbers * 100;
            double percentNumbersFrom600To799 = numbersFrom600To799 / totalNumbers * 100;
            double percentNumbersFrom800 = numbersFrom800 / totalNumbers * 100;

            Console.WriteLine(percentNumbersTo200 + "%");
            Console.WriteLine(percentNumbersFrom200To399 + "%");
            Console.WriteLine(percentNumbersFrom400To599 + "%");
            Console.WriteLine(percentNumbersFrom600To799 + "%");
            Console.WriteLine(percentNumbersFrom800 + "%");
        }
    }
}
