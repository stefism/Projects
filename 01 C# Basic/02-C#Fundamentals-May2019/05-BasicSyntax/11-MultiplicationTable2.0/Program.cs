using System;

namespace _11_MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine()); 
            int secondNumber = int.Parse(Console.ReadLine());

            int result = 0;

            if (secondNumber > 10)
            {
                result = firstNumber * secondNumber;
                Console.WriteLine($"{firstNumber} X {secondNumber} = {result}");
                return;
            }

            else
            {
                for (int i = secondNumber; i <= 10; i++)
                {
                    result = firstNumber * i;
                    Console.WriteLine($"{firstNumber} X {i} = {result}");
                }
            }
        }
    }
}
