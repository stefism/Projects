 using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int maxNumberValue = 0;

            for (int compare = 0; compare < number; compare++)
            {
                maxNumberValue = int.Parse(Console.ReadLine());

                if (maxNumberValue > maxNumber)
                {
                    maxNumber = maxNumberValue;
                }
            }

            Console.WriteLine(maxNumber);
        }
    }
}
