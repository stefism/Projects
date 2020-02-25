using System;

namespace _11MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            double result = CalculateOperationsInTwoNumbes(firstNumber, @operator, secondNumber);
            Console.WriteLine(result);
        }

        private static double CalculateOperationsInTwoNumbes(int a, string @operator, int b)
        {
            double result = 0;

            switch (@operator)
            {
                case "+":
                    result = a + b;
                    break;

                case "-":
                    result = a - b;
                    break;

                case "*":
                    result = a * b;
                    break;

                case "/":
                    result = a / b;
                    break;
            }

            return result;
        }
    }
}
