using System;

namespace EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int partNumbers = int.Parse(Console.ReadLine());
            double sum = 0;
            double sum2 = 0;
            double diff = 0;

            for (int n = 0; n < partNumbers; n++)
            {
                //sum = 0;
                double number1 = double.Parse(Console.ReadLine());
                double number2 = double.Parse(Console.ReadLine());
                sum = number1 + number2;

                if (sum != sum2)
                {
                    diff = sum2 - sum;
                }
                else if (sum == sum2)
                {
                    diff = 0;
                }

                sum2 = sum;
            }

            if (diff == 0)
            {
                Console.WriteLine($"Yes, value={sum2}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={Math.Abs(diff)}");
            }
        }
    }
}
