using System;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int biggerNumber = int.MinValue;
            int lowestNumber = int.MaxValue;

            while (true)
            {
                string numberOrEnd = Console.ReadLine();
                if (numberOrEnd == "END")
                {
                    break;
                }

                int number = int.Parse(numberOrEnd);

                if (number < lowestNumber)
                {
                    lowestNumber = number;
                }

                if (number > biggerNumber)
                {
                    biggerNumber = number;
                }
            }

            Console.WriteLine($"Max number: {biggerNumber}");
            Console.WriteLine($"Min number: {lowestNumber}");
        }
    }
}
