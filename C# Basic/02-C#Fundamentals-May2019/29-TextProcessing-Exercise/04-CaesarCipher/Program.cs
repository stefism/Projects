using System;

namespace _04_CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string cryptedText = string.Empty;

            foreach (var @char in inputString)
            {
                char cryptedChar = (char)(@char + 3);
                cryptedText += cryptedChar;
            }

            Console.WriteLine(cryptedText);
        }
    }
}
