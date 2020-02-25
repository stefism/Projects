using System;

namespace _09PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    return;
                }

                int number = int.Parse(input);

                bool resultOfCompare = PalindromeIntegers(number);

                if (resultOfCompare)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool PalindromeIntegers(int number)
        {
            string numberToString = number.ToString();
            string reverseString = ReverseText(numberToString);

            int compareStringResult = numberToString.CompareTo(reverseString);

            if (compareStringResult == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string ReverseText(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = string.Empty;

            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }

            return reverse;
        }
    }
}
