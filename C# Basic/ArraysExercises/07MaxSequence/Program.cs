using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://pastebin.com/ewvVJQyz Тази задача ми е трудна, решението не е мое.

            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); // 2 3 3 3 3 2 2

            int length = 1;
            int maxSequenceNumber = 0;
            int bestLength = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    length++;
                    if (length > bestLength)
                    {
                        bestLength = length;
                        maxSequenceNumber = input[i];
                    }
                }

                else
                {
                    length = 1;
                }
            }

            for (int i = 0; i < bestLength; i++)
            {
                Console.Write(maxSequenceNumber + " ");
            }
        }
    }
}