using System;

namespace _02_CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split();
            string[] secondArr = Console.ReadLine().Split();

            for (int i = 0; i < secondArr.Length; i++)
            {
                string secondElement = secondArr[i];

                for (int j = 0; j < firstArr.Length; j++)
                {
                    string firstElement = firstArr[j];

                    if (secondElement == firstElement)
                    {
                        Console.Write(secondElement + " ");
                    }
                }
            }
        }
    }
}
