using System;

namespace _05_MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberAsString = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            string finalResultToString = string.Empty;

            int extraDigit = 0;

            for (int i = numberAsString.Length-1; i >= 0; i--)
            {
                int currentDigit = int.Parse(numberAsString[i].ToString());

                //int extraDigit = 0;
                int lastDigit = 0;
                int finalResult = 0;

                int currentResult = currentDigit * multiplier;
                string resultToString = currentResult.ToString();

                if (resultToString.Length > 1)
                {
                    extraDigit = int.Parse(resultToString[0].ToString());
                    lastDigit = int.Parse(resultToString[1].ToString());

                    if (i == numberAsString.Length - 1)
                    {
                        finalResult = lastDigit;
                    }
                    else
                    {
                        finalResult = lastDigit + extraDigit;
                    }
                }

                else
                {
                    lastDigit = int.Parse(resultToString[0].ToString());
                    finalResult = lastDigit + extraDigit;
                }

                finalResultToString += finalResult.ToString();

                if (i == 0 && resultToString.Length > 1)
                {
                    finalResultToString += resultToString[0];
                }
            }

            string lastResult = Reverse(finalResultToString);
            Console.WriteLine(lastResult);
        }

        static string Reverse(string reversedString)
        {
            char[] charArray = reversedString.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
