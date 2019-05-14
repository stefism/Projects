using System;

namespace _08FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());

            double facturiel1 = CalculateFactorialFromNumber(number1);
            double facturiel2 = CalculateFactorialFromNumber(number2);

            double divideResult = facturiel1 / facturiel2;

            Console.WriteLine("{0:F2}", divideResult);
        }

        static double CalculateFactorialFromNumber(double number)
        {
            double result = 1;

            while (number != 1)
            {
                result *= number;
                number -= 1;
            }

            return result;
        }
    }
}
