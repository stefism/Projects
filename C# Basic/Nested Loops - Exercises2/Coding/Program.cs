using System;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                // Console.WriteLine(number[i]); // това ми е за проба да извади числата отделно като символ обаче

                int realNumber = (int)char.GetNumericValue(number[i]);
                // Console.WriteLine($"Number form char {realNumber}");

                int numberFromChar = number[i];
                int charFromNumber = numberFromChar - 15;

                if (realNumber == 0)
                {
                    Console.WriteLine("ZERO");
                }

                for (int numberOfPrintChar = 0; realNumber > numberOfPrintChar; numberOfPrintChar++)
                {
                    Console.Write((char)charFromNumber);
                }

                if (realNumber != 0)
                {
                    Console.WriteLine("");
                }
                
                // Console.WriteLine((char)charFromNumber); // това изкарва правилните символи


            }


        }
    }
}
