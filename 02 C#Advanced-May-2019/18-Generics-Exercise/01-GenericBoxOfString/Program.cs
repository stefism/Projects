using System;

namespace _01_GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfInput = int.Parse(Console.ReadLine());

            var box = new Box<double>();

            for (int i = 0; i < numberOfInput; i++)
            {
                double input = double.Parse(Console.ReadLine());

                box.Add(input);
            }

            double stringToCompare = double.Parse(Console.ReadLine());

            int count = box.CountThatGreaterByValue(stringToCompare);

            Console.WriteLine(count);
        }
    }
}
