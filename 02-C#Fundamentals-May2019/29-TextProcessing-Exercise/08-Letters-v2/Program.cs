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

                int positionFirstLetterString = CharAlphabetNumber(firstLetterString);
                int positionLastLetterString = CharAlphabetNumber(lastLetterString);

                //Изчисляваме сумата на текущия  string.
                double sumFromString = CalculateSumFromLetters(isFirstLetterStringIsUpper,
                    isLastLetterStringIsUpper, numberString, positionFirstLetterString,
                    positionLastLetterString);

                //Изчисляваме крайния резултат
                finalResult += sumFromString;
            }

            Console.WriteLine($"{Math.Abs(finalResult):F2}");
        }

        static double CalculateSumFromLetters(bool isFirstUpper, bool isLastUpper, int number, int firstPosition, int lastPosition)
        {
            double sum = 0;

            if (isFirstUpper)
            {
                sum = number / firstPosition;
            }
            else
            {
                sum = number * firstPosition;
            }

            if (isLastUpper)
            {
                sum -= lastPosition;
            }
            else
            {
                sum += lastPosition;
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
