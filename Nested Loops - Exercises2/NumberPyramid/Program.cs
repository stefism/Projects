using System;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNumber = int.Parse(Console.ReadLine());
            int numbersOnRow = 1;

            for (int currentNumber = 1; currentNumber <= totalNumber; currentNumber++)
            {
                for (int j = 1; j <= numbersOnRow; j++)
                {
                    if (currentNumber > totalNumber)
                    {
                        break;
                    }
                    Console.Write(currentNumber + " ");
                    currentNumber++;
                }
                currentNumber--;
                numbersOnRow++;
                Console.WriteLine();
            }
        }
    }
}
