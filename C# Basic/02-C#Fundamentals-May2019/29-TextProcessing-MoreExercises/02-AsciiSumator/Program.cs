using System;

namespace _02_AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char lastChar = char.Parse(Console.ReadLine());

            string inputString = Console.ReadLine();

            int firstCharIndex = firstChar;
            int lastCharIndex = lastChar;

            double sumFromChar = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] > firstCharIndex && inputString[i] < lastCharIndex)
                {
                    sumFromChar += inputString[i];
                }
            }

            Console.WriteLine(sumFromChar);
        }
    }
}
