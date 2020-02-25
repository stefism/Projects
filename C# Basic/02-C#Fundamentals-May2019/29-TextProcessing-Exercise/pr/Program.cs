using System;

namespace _07_StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splitedInput = input.Split(">");

            string result = splitedInput[0];
            int remainingPower = 0;

            for (int i = 1; i < splitedInput.Length; i++)
            {
                result += ">";

                string currentString = splitedInput[i];
                char digitSymbol = currentString[0];

                int power = int.Parse(digitSymbol.ToString()) + remainingPower;

                if (power > currentString.Length)
                {
                    remainingPower = power - currentString.Length;
                }
                else
                {
                    result += currentString.Substring(power);
                }
            }

            Console.WriteLine(result);
        }
    }
}
