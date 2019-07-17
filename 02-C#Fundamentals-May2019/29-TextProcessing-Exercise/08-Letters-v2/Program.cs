using System;
using System.Linq;

namespace _08_LettersChangeNumbers_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Прочитаме двата стринга.
            string[] inputString = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            // Инициализираме променлива за крайния резултат.
            double finalResult = 0;

            foreach (var @string in inputString)
            {
                //Изваждаме си първата буква, последната буква и числото от текущия string.
                char firstLetterString = @string[0];
                char lastLetterString = @string[@string.Length - 1];
                int numberString = int.Parse(@string.Substring(1, @string.Length - 2));

                //Взимаме информация за първата и последната буква дали са главни и на
                //коя позиция са първата и последната буква на текущия string.
                bool isFirstLetterStringIsUpper = IsCharIsUpper(firstLetterString);
                bool isLastLetterStringIsUpper = IsCharIsUpper(lastLetterString);

                int positionFirstLetterString = Math.Abs(CharAlphabetNumber(firstLetterString));
                int positionLastLetterString = Math.Abs(CharAlphabetNumber(lastLetterString));

                //Изчисляваме сумата на текущия  string.
                double sumFromString = CalculateSumFromLetters(isFirstLetterStringIsUpper,
                    isLastLetterStringIsUpper, numberString, positionFirstLetterString,
                    positionLastLetterString);

                //Изчисляваме крайния резултат
                finalResult += (sumFromString * 1.0);
            }

            Console.WriteLine($"{Math.Abs(finalResult):F2}");
        }

        static double CalculateSumFromLetters(bool isFirstUpper, bool isLastUpper, int number, int firstPosition, int lastPosition)
        {
            double sum = 0;

            if (isFirstUpper)
            {
                sum = number / (firstPosition * 1.0);
            }
            else
            {
                sum = number * (firstPosition * 1.0);
            }

            if (isLastUpper)
            {
                sum -= (lastPosition * 1.0);
            }
            else
            {
                sum += (lastPosition * 1.0);
            }

            return sum;
        }

        static bool IsCharIsUpper(char @char)
        {
            if (@char >= 65 && @char <= 90)
            {
                return true;
            }

            return false;
        }

        static int CharAlphabetNumber(char @char)
        {
            bool isUpper = IsCharIsUpper(@char);
            int charOrder = 0;

            if (isUpper)
            {
                charOrder = 64 - @char;
            }
            else
            {
                charOrder = 96 - @char;
            }

            return charOrder;
        }
    }
}
