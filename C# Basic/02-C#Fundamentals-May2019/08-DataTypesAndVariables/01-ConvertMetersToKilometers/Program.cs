using System;

namespace _01_ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());
            double kilometers = meters / 1000;

            Console.WriteLine("{0:F2}", kilometers);
        }
    }
}
