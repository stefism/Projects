using System;

namespace _01SmalestOf3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            int result = SmalestOfThreeNumbers(numberOne, numberTwo, numberThree);
            Console.WriteLine(result);


        }

        static int SmalestOfThreeNumbers(int numberOne, int numberTwo, int numberThree)
        {
            int smalestNumber = int.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                if (numberOne < smalestNumber)
                {
                    smalestNumber = numberOne;
                }
                else if (numberTwo < smalestNumber)
                {
                    smalestNumber = numberTwo;
                }
                else if (numberThree < smalestNumber)
                {
                    smalestNumber = numberThree;
                }
            }

            return smalestNumber;
        }
    }
}
