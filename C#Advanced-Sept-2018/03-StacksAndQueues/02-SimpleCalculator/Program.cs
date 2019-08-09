using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> calculatorArgs = new Stack<string>(input.Reverse());

            while (calculatorArgs.Count > 1)
            {
                int firstNumber = int.Parse(calculatorArgs.Pop());
                char operand = char.Parse(calculatorArgs.Pop());
                int secondNumber = int.Parse(calculatorArgs.Pop());

                if (operand == '+')
                {
                    calculatorArgs.Push((firstNumber + secondNumber).ToString());
                }
                else
                {
                    calculatorArgs.Push((firstNumber - secondNumber).ToString());
                }
            }

            Console.WriteLine(calculatorArgs.Pop());
        }
    }
}
