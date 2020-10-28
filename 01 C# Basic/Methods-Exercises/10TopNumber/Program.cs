using System;

namespace _10TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
           
            for (int i = 1; i <= number; i++)
            {
                bool isOddDigitExist = IsOddDigitExist(i);
                if (isOddDigitExist)
                {
                    bool isDivideBy8 = IsDivideBy8(i);
                    if (isDivideBy8)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }

        static bool IsOddDigitExist(int number)
        {
            int Digit = number;

            while (Digit > 0)
            {
                int currentDigit = Digit % 10;

                if (Digit % 2 == 1)
                {
                    return true;
                }

                Digit /= 10;
            }

            return false;
        }

        static bool IsDivideBy8(int number)
        {
            int Digit = number;
            int sum = 0;

            while (Digit > 0)
            {
                int currentDigit = Digit % 10;
                sum += currentDigit;
                Digit /= 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
