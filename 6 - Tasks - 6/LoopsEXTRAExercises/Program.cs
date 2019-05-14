using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // 12 януари 2019, Задача 6. Числа

            string numberAsString = Console.ReadLine();

            int number = int.Parse(numberAsString);

            int digit1 = (int)char.GetNumericValue(numberAsString[0]);
            int digit2 = (int)char.GetNumericValue(numberAsString[1]);
            int digit3 = (int)char.GetNumericValue(numberAsString[2]);

            int rowNumber = digit1 + digit2;
            int columnNumber = digit1 + digit3;
            int totalPrintNumbers = rowNumber * columnNumber;

            int counterRow = 1;
            int counterColumn = 0;

            for (int i = 0; i < totalPrintNumbers; i++)
            {
                if (number % 5 == 0)
                {
                    number = number - digit1;
                    Console.Write(number + " ");
                    counterColumn++;
                }
                else if (number % 3 == 0)
                {
                    number = number - digit2;
                    Console.Write(number + " ");
                    counterColumn++;
                }
                else
                {
                    number = number + digit3;
                    Console.Write(number + " ");
                    counterColumn++;
                }

                if (counterColumn == columnNumber)
                {
                    Console.WriteLine();
                    counterColumn = 0;
                }
                //counterColumn = 0;
            }

        }
    }
}
