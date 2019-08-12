using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_CalculateSequence_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            long inputNumber = long.Parse(Console.ReadLine());

            Queue<long> numbers = new Queue<long>();

            List<long> output = new List<long>();

            numbers.Enqueue(inputNumber);

            output.Add(inputNumber);

            for (int i = 0; i < 17; i++)
            {
                long currentNumber = numbers.Dequeue();

                long s2 = currentNumber + 1;
                long s3 = 2 * currentNumber + 1;
                long s4 = currentNumber + 2;

                numbers.Enqueue(s2);
                numbers.Enqueue(s3);
                numbers.Enqueue(s4);

                output.Add(s2);
                output.Add(s3);
                output.Add(s4);
            }

            Console.WriteLine(string.Join(" ", output.Take(50)));
        }
    }
}
