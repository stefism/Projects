using System;

namespace MultiplyTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int n1 = (int)char.GetNumericValue(number[0]);
            int n2 = (int)char.GetNumericValue(number[1]);
            int n3 = (int)char.GetNumericValue(number[2]);

            for (int number1 = 1; number1 <= n3; number1++)
            {
                for (int number2 = 1; number2 <= n2; number2++)
                {
                    for (int number3 = 1; number3 <= n1; number3++)
                    {
                        double result = number1 * number2 * number3;
                        Console.WriteLine($"{number1} * {number2} * {number3} = {result};");
                    }
                }
            }


        }
    }
}
