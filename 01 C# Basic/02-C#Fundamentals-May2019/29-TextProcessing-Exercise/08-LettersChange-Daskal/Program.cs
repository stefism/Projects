using System;

namespace _08_LettersChange_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splitedInput = Console.ReadLine().Split(new char[] {' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            double totalSum = 0;

            for (int i = 0; i < splitedInput.Length; i++)
            {
                string currentInput = splitedInput[i];

                char firstLetter = currentInput[0];
                char lastLetter = currentInput[currentInput.Length-1];
                double digit = double.Parse(currentInput.Substring(1, currentInput.Length - 2));

                if (char.IsUpper(firstLetter))
                {
                    digit /= firstLetter - 'A' + 1;
                }
                else
                {
                    digit *= firstLetter - 'a' + 1;
                }

                if (char.IsUpper(lastLetter))
                {
                    digit -= lastLetter - 'A' + 1;
                }
                else
                {
                    digit += lastLetter - 'a' + 1;
                }

                totalSum += digit;
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
