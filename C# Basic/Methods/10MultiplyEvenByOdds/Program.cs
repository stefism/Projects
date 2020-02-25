using System;
using System.Linq;

namespace _10MultiplyEvenByOdds
{
    class Program
    {
        static int evenSum = 0;
        static int oddSum = 0;

        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            GetSumOfEvenAndOddDigits(number);
            Console.WriteLine(evenSum * oddSum);
        }

        static void GetSumOfEvenAndOddDigits(string number)
        {
            evenSum = 0;
            oddSum = 0;

            if (number[0] == '-')
            {
                for (int i = 1; i < number.Length; i++)
                {
                    if (number[i] % 2 == 0)
                    {
                        int numberFromChar = (int)Char.GetNumericValue(number[i]);
                        evenSum += numberFromChar;
                    }
                    else
                    {
                        int numberFromChar = (int)Char.GetNumericValue(number[i]);
                        oddSum += numberFromChar;
                    }
                }
                // Console.WriteLine($"Even sum: {evenSum}");
                // Console.WriteLine($"Odd sum: {oddSum}");
            }
            else
            {
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] % 2 == 0)
                    {
                        int numberFromChar = (int)Char.GetNumericValue(number[i]);
                        evenSum += numberFromChar;
                    }
                    else
                    {
                        int numberFromChar = (int)Char.GetNumericValue(number[i]);
                        oddSum += numberFromChar;
                    }
                }
                //Console.WriteLine($"Even sum: {evenSum}");
                //Console.WriteLine($"Odd sum: {oddSum}");
            }
        }
    }
}
