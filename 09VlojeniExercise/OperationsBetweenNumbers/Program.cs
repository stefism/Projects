using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string action = Console.ReadLine();

            double result = 0;

            if ((action == "/" || action == "%") && n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
            else
            {
                switch (action)
                {
                    case "+":
                        result = n1 + n2;
                        break;

                    case "-":
                        result = n1 - n2;
                        break;

                    case "*":
                        result = n1 * n2;
                        break;

                    case "/":
                        result = n1 / n2;
                        break;

                    case "%":
                        result = n1 % n2;
                        break;
                }
                string evenOrOdd = "";

                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }

                if (action == "+" || action == "-" || action == "*")
                {
                    Console.WriteLine($"{n1} {action} {n2} = {result} - {evenOrOdd}");
                }
                else if (action == "/")
                {
                    Console.WriteLine($"{n1} / {n2} = {result:F2}");
                }
                else if (action == "%")
                {
                    Console.WriteLine($"{n1} % {n2} = {n1 % n2}");
                }
            }

        }
    }
}
