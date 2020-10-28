using System;
using System.Linq;

namespace ArrayAndMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1, 2, 3, 4, 5
            // Max
            // Print

            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int index = int.Parse(Console.ReadLine());
            Exchange(numbers, index);
            Console.WriteLine(string.Join(" ", numbers));
        }

        // Метод за размяна местата на масив по въведен индекс

        private static void Exchange(int[] numbers, int index)
        {
            int[] leftNumbers = new int[index + 1];
            int[] rightNumbers = new int[numbers.Length - index - 1];

            for (int i = 0; i < leftNumbers.Length; i++)
            {
                leftNumbers[i] = numbers[i];
            }

            int counter = 0;

            for (int i = leftNumbers.Length; i < numbers.Length; i++)
            {
                rightNumbers[counter++] = numbers[i];
                //counter++;
            }

            int[] arrayResult = new int[numbers.Length];

            for (int i = 0; i < rightNumbers.Length; i++)
            {
                arrayResult[i] = rightNumbers[i];
            }

            counter = 0;

            for (int i = rightNumbers.Length; i < arrayResult.Length; i++)
            {
                arrayResult[i] = leftNumbers[counter++];
                //counter++; горе онова прави същото.
            }

            Console.WriteLine(string.Join(" ", arrayResult));
        }

        // Метод, който намира дали дадено число се съдържа в даден масив.

        private static bool Contains(int[] numbers, int targetNumber)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == targetNumber)
                {
                    return true;
                }
            }

            return false;
        }
        
        // Метод, който връща най-малкото число.

        private static int GetMinNumber(int[] numbers)
        {
            int minNumber = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            return minNumber;
        }

        // Мой метод, който връща най-голямато число измежду други числа от даден масив.

        private static int GetMaxNumber(int[] numbers)
        {
            int maxNumber = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            return maxNumber;
        }
    }
}
