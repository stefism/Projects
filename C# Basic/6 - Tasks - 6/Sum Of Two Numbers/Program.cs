
using System;

namespace Sum_Of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // // От допълнителните упражнения за циклите Nested Loops More Exercises - Exercise

            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int sum = 0;
            int counterCombination = 0;

            for (int tens = startNumber; tens <= endNumber; tens++)
            {
                for (int units = startNumber; units <= endNumber; units++)
                {
                    counterCombination++;

                    sum = tens + units;

                    if (sum == magicNumber)
                    {
                        Console.Write($"Combination N:{counterCombination} ");
                        Console.WriteLine($"({tens} + {units} = {sum})");
                        return;
                    }

                    sum = 0;
                }
            }

            if (sum != magicNumber)
            {
                Console.WriteLine($"{counterCombination} combinations - neither equals {magicNumber}");
            }
            
        }
    }
}
