using System;

namespace _01_GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfInput = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < numberOfInput; i++)
            {
                var input =Console.ReadLine();

                box.Add(input);
            }

            var stringToCompare = Console.ReadLine();

            int count = box.CountThatGreaterByValue(stringToCompare);

            Console.WriteLine(count);
        }
    }
}
