using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long inputNumber = long.Parse(Console.ReadLine()); //  1 - S1

            Queue<long> numbers = new Queue<long>();

            Console.Write(inputNumber + " ");

            for (int i = 1; i <= 50; i++)
            {
                long outputNumber = inputNumber + 1; // 2 - S2 

                Console.Write(outputNumber + " ");

                numbers.Enqueue(outputNumber); // save s2

                outputNumber = 2 * inputNumber + 1; // 3 - S3

                //numbers.Enqueue(outputNumber); // save s3

                Console.Write(outputNumber + " ");

                //numbers.Dequeue();

                numbers.Enqueue(outputNumber); // save s3

                outputNumber = inputNumber + 2; //  4 - S4 = S1 + 2

                Console.Write(outputNumber + " ");

                //numbers.Enqueue(outputNumber); // save s3

                inputNumber = numbers.Dequeue();
            }
        }
    }
}
