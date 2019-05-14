using System;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int totalCounter = 0;

            double minNumberOdd = int.MaxValue;
            double minNumberEven = int.MaxValue;

            double maxNumberOdd = int.MinValue;
            double maxNumberEven = int.MinValue;

            double oddSum = 0;
            double evenSum = 0;

            for (int n = 0; n < numbers; n ++)
            {
                double number = double.Parse(Console.ReadLine());
                totalCounter++;

                if (totalCounter % 2 == 1)
                {
                    oddSum += number;

                    if (number > maxNumberOdd)
                    {
                        maxNumberOdd = number;
                    }

                    if (number < minNumberOdd)
                    {
                        minNumberOdd = number;
                    }
                }

                if (totalCounter % 2 == 0)
                {
                    evenSum += number;

                    if (number > maxNumberEven)
                    {
                        maxNumberEven = number;
                    }

                    if (number < minNumberEven)
                    {
                        minNumberEven = number;
                    }
                }

            }

            Console.WriteLine($"OddSum={oddSum:F2},");

            if (minNumberOdd == int.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={minNumberOdd:F2},");
            }

            if (maxNumberOdd == int.MinValue)
            {
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMax={maxNumberOdd:F2},");
            }
            
            Console.WriteLine($"EvenSum={evenSum:F2},");

            if (minNumberEven == int.MaxValue)
            {
                Console.WriteLine("EvenMin=No,");
            }
            else
            {
                Console.WriteLine($"EvenMin={minNumberEven:F2},");
            }

            if (maxNumberEven == int.MinValue)
            {
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMax={maxNumberEven:F2}");
            }

            
            
        }
    }
}
