using System;

namespace NumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            int[] number = new int[numbers];

            for (int i = 0; i < numbers; i++)
            {
                number [i] = int.Parse(Console.ReadLine());
            }

            for (int i = number.Length - 1; i >= 0; i--)
            {
                Console.Write(number[i] + " ");
            }
        }
    }
}
