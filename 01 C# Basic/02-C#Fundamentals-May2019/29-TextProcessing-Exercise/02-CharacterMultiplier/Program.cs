using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputString = Console.ReadLine().Split();

            string string1 = inputString[0];
            string string2 = inputString[1];

            int sum = 0;

            for (int i = 0; i < Math.Min(string1.Length, string2.Length); i++)
            {
                sum += string1[i] * string2[i];
            }

            if (string1.Length > string2.Length)
            {
                int extraLenght = string1.Length - string2.Length;

                for (int i = string1.Length-extraLenght; i <= extraLenght; i++)
                {
                    sum += string1[i];
                }
            }

            else if (string2.Length > string1.Length)
            {
                int extraLenght = string2.Length - string1.Length;

                for (int i = string2.Length-extraLenght; i <= extraLenght; i++)
                {
                    sum += string2[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
