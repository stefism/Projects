using System;
using System.Linq;

namespace _03ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            string result1 = "";
            string result2 = "";

            int counterLines = 0;

            int[] array1 = new int[2];
            int[] array2 = new int[2];

            while (counterLines != numberOfLines)
            {
                array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                counterLines++;

                if (counterLines == numberOfLines)
                {
                    result1 += array1[0] + " ";
                    result2 += array1[1] + " ";
                    break;
                }

                array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                counterLines++;

                result1 += array1[0] + " " + array2[1] + " ";
                result2 += array1[1] + " " + array2[0] + " ";
            }

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
    }
}
