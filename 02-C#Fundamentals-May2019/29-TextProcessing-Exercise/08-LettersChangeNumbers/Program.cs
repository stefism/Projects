using System;
using System.Linq;

namespace _08_LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Прочитаме двата стринга.
            string[] inputString = Console.ReadLine().Split();

            //Присвояваме първия и втория стринг на променливи.
            string string1 = inputString[0];
            string string2 = inputString[1];

            //Изваждаме си първата буква, последната буква и числото от string1.
            char firstLetterString1 = string1[0];
            char lastLetterString1 = string1[string1.Length - 1];
            int numberString1 = int.Parse(string1.Substring(1, string1.Length - 2));

            //Изваждаме си първата буква, последната буква и числото от string2.
            char firstLetterString2 = string2[0];
            char lastLetterString2 = string2[string2.Length - 1];
            int numberString2 = int.Parse(string2.Substring(1, string2.Length - 2));

            //Взимаме информация за първата и последната буква дали са главни и на
            //коя позиция са първата и последната буква на string1.
            bool isFirstLetterString1isUpper = IsCharIsUpper(firstLetterString1);
            bool isLastLetterString1isUpper = IsCharIsUpper(lastLetterString1);

            int positionFirstLetterString1 = CharAlphabetNumber(firstLetterString1);
            int positionLastLetterString1 = CharAlphabetNumber(lastLetterString1);

            //Изчисляваме сумата от  string1.
            double sumFromString1 = CalculateSumFromLetters(isFirstLetterString1isUpper,
                isLastLetterString1isUpper, numberString1, positionFirstLetterString1,
                positionLastLetterString1);

            //Взимаме информация за първата и последната буква дали са главни и на
            //коя позиция са първата и последната буква на string2.
            bool isFirstLetterString2IsUpper = IsCharIsUpper(firstLetterString2);
            bool isLastLetterString2IsUpper = IsCharIsUpper(lastLetterString2);

            int positionFirstLetterString2 = CharAlphabetNumber(firstLetterString2);
            int positionLastLetterString2 = CharAlphabetNumber(lastLetterString2);

            //Изчисляваме сумата от string2.
            double sumFromString2 = CalculateSumFromLetters(isFirstLetterString2IsUpper,
                isLastLetterString2IsUpper, numberString2, positionFirstLetterString2,
                positionLastLetterString2);

            //Изчисляваме крайния резултат
            double finalResult = sumFromString1 + sumFromString2;

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
