using System;
using System.Linq;


namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sumEqual = 0;

            bool arrayEquals = false;

            for (int i = 0; i < numbers1.Length; i++)
            {
                if (numbers1[i] != numbers2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    arrayEquals = false;
                    break;
                }
                else
                {
                    arrayEquals = true;
                    sumEqual += numbers1[i];
                    //Console.Write($"Arrays are identical. ");
                }

            }

            if (arrayEquals)
            {
                Console.Write($"Arrays are identical. ");
                Console.WriteLine($"Sum: {sumEqual}");
            }

        }
    }
}

