using System;

namespace _06_StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberInString = Console.ReadLine();
            int number = int.Parse(numberInString);

            int factorialSum = 0;

            for (int i = 0; i < numberInString.Length; i++)
            {
                int currentNumber = (int)Char.GetNumericValue(numberInString[i]);

                int factorial = 1;

                for (int j = 1; j <= currentNumber; j++)
                {
                    factorial *= j;
                }

                factorialSum += factorial;
            }

            if (factorialSum == number)
            {
                Console.WriteLine("yes");
            }

            else
            {
                Console.WriteLine("no");     
            }
        }
    }
}
