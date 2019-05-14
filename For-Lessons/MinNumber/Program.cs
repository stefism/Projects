using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int minNumber = int.MaxValue;
            int minNumberValue = 0;

            for (int compare = 0; compare < number; compare++)
            {
                minNumberValue = int.Parse(Console.ReadLine());

                if (minNumberValue < minNumber)
                {
                    minNumber = minNumberValue;
                }
            }

            Console.WriteLine(minNumber);
        }
    }
}
