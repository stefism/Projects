using System;

namespace UsDtoLeva
{
    class Program
    {
        static void Main(string[] args)
        {
            double exchangeRate = double.Parse(Console.ReadLine());
            double ratioUSD = 1.79549;
            double resultCourse = exchangeRate * ratioUSD;
            Console.WriteLine(Math.Round(resultCourse, 2));

        }
    }
}
