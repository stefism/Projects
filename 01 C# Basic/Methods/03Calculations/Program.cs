using System;

namespace _03Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            if (operation == "add")
            {
                AddTwoNumbers(number1, number2);
            }

            else if (operation == "multiply")
            {
                MultiplyTwoNumbers(number1, number2);
            }

            else if (operation == "subtract")
            {
                SubtractTwoNumbers(number1, number2);
            }

            else if (operation == "divide")
            {
                DivideTwoNumbers(number1, number2);
            }
        }

        static void AddTwoNumbers(int numberOne, int numberTwo)
        {
            Console.WriteLine(numberOne + numberTwo);
        }

        static void MultiplyTwoNumbers(int numberOne, int numberTwo)
        {
            Console.WriteLine(numberOne * numberTwo);
        }

        static void SubtractTwoNumbers(int numberOne, int numberTwo)
        {
            Console.WriteLine(numberOne - numberTwo);
        }

        static void DivideTwoNumbers(int numberOne, int numberTwo)
        {
            Console.WriteLine(numberOne / numberTwo);
        }
    }
}
