using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine(MathPower(number, power));

        }

        static double MathPower(double number, double power)
        {

            double result = Math.Pow(number, power);

            return result;
        }


    }
}
