using System;
using System.Linq;

namespace _04PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberTriangle = int.Parse(Console.ReadLine());
            PrintingTriangle(numberTriangle);
        }

        static void PrintingTriangle(int number)
        {
            int[] numberArr = new int[number];
            string numberAsString = "";

            int counter = 0;

            for (int i = 1; i <= numberArr.Length; i++)
            {
                numberArr[counter] = i;
                counter++;
            }

            for (int i = 0; i < numberArr.Length; i++)
            {
                numberAsString += numberArr[i] + " ";
                Console.WriteLine(numberAsString + " ");
            }

            for (int i = 1; i <= number; i++)
            {
                Array.Resize(ref numberArr, numberArr.Length - 1);
                Console.WriteLine(string.Join(" ", numberArr));
            }
        }
    }
}
