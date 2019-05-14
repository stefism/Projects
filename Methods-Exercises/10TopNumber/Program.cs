using System;

namespace _10TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            

            for (int i = 16; i <= number; i++)
            {
                int sum = SumFromDigitInNumber(i);
                bool isSumDivide = false;

                for (int j = 8; j < number; j++)
                {
                    if (sum == j)
                    {
                        isSumDivide = true;
                    }
                    else if (sum > j)
                    {
                        j += 8;
                    }
                }

                bool isContain = IsContainLeastOneDigit(i);

                if (isSumDivide && isContain)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static int SumFromDigitInNumber(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        static bool IsContainLeastOneDigit(int number)
        {
            while (number != 0)
            {
                if (number % 10 == 1)
                {
                    return true;
                }
                number /= 10;
            }

            return false;
        }
    }
}
