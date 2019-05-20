using System;

namespace _05_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            string output = "";

            for (int i = 0; i < numberOfNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                char letter = ConvertNumberToChar(number);
                output += letter;
            }

            Console.WriteLine(output);
        }

        static char ConvertNumberToChar(int number)
        {
            double numberLength = Math.Ceiling(Math.Log10(number));
            int mainDigit = number % 10;
            int offset = (mainDigit - 2) * 3;

            if (mainDigit == 8 || mainDigit == 9)
            {
                offset += 1;
            }

            double letterIndex = offset + numberLength - 1;
            double charIndex = letterIndex + 97;

            char letter = (char)charIndex;

            if (mainDigit == 0)
            {
                return ' ';
            }
            else
            {
                return letter;
            }
        }
    }
}
