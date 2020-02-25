using System;

namespace _05AddAndSubstract
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            SumOfFirstTwoIntegers(number1, number2);
            Console.WriteLine(SubstractFromFirstMethod(number1, number2, number3));
        }

        static int SumOfFirstTwoIntegers(int number1, int number2)
        {
            int result = number1 + number2;
            return result;
        }

        static int SubstractFromFirstMethod(int number1, int number2, int number3)
        {
            int substractResult = SumOfFirstTwoIntegers(number1, number2) - number3;
            return substractResult;
        }

    }
}
