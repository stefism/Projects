using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _05_DigitsLattersAndOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            string digits = string.Empty;
            string letters = string.Empty;
            string others = string.Empty;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (char.IsDigit(inputString[i]))
                {
                    digits += inputString[i];
                }

                else if (char.IsLetter(inputString[i]))
                {
                    letters += inputString[i];
                }

                else
                {
                    others += inputString[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
