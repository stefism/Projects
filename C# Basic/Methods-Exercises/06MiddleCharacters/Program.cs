using System;

namespace _06MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            GetMiddleSharactersFromString(input);
        }

        static void GetMiddleSharactersFromString(string input)
        {
            if (input.Length % 2 == 1)
            {
                Console.WriteLine(input[input.Length / 2]);
            }
            else
            {
                Console.WriteLine(input[(input.Length / 2)-1] + "" + input[(input.Length / 2)]);
            }
        }
    }
}
