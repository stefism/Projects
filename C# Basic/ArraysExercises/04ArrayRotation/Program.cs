using System;
using System.Linq;

namespace _04ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int arrayRotation = int.Parse(Console.ReadLine());

            if (arrayRotation == 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            int lastNumber = numbers[0];

            int indexRotate = 0;

            int[] rotation = new int[numbers.Length];

            for (int i = 0; i < arrayRotation; i++)
            {
                for (int j = 1; j < numbers.Length; j++)
                {
                    rotation[indexRotate] = numbers[j];
                    indexRotate++;
                }

                rotation[rotation.Length-1] = lastNumber;

                indexRotate = 0;

                lastNumber = rotation[0];
                numbers = rotation;
            }

            Console.WriteLine(string.Join(" ", rotation));
        }
    }
}
