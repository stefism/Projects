using System;

namespace _09GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int intNumber1 = int.Parse(Console.ReadLine());
                int intNumber2 = int.Parse(Console.ReadLine());
                int resultInt = GetMax(type, intNumber1, intNumber2);
                Console.WriteLine(resultInt);
            }
            else if (type == "char")
            {
                char char1 = char.Parse(Console.ReadLine());
                char char2 = char.Parse(Console.ReadLine());
                int resultChar = GetMax(type, char1, char2);
                Console.WriteLine((char)resultChar);
            }
            else if (type == "string")
            {
                string string1 = Console.ReadLine();
                string string2 = Console.ReadLine();
                string resultString = GetMax(type, string1, string2);
                Console.WriteLine(resultString);
            }

        }

        static  int GetMax(string type, int numberOne, int numberTwo)
        {

            if (numberOne > numberTwo)
            {
                return numberOne;
            }
            else
            {
                return numberTwo;
            }
        }

        static char GetMax(string type, char char1, char char2)
        {
            if (char1 > char2)
            {
                return char1;
            }
            else
            {
                return char2;
            }
        
        }

        static string GetMax(string type, string string1, string string2)
        {
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < string1.Length; i++)
            {
                int charToInt = string1[i];
                sum1 += charToInt;
            }

            for (int i = 0; i < string1.Length; i++)
            {
                int charToInt = string2[i];
                sum2 += charToInt;
            }

            if (sum1 > sum2)
            {
                return string1;
            }
            else
            {
                return string2;
            }
        }
    }
}
