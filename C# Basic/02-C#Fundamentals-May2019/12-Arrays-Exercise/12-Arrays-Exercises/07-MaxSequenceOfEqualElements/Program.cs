using System;
using System.Linq;

namespace _07_MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            int repeatIndex = 0;
            int maxCounter = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                int repeatCounter = 1;

                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[j] == numbers[i])
                    {
                        repeatCounter++;
                        
                        if (repeatCounter > maxCounter)
                        {
                            maxCounter = repeatCounter;
                            repeatIndex = numbers[i];
                        }
                    }
                    else
                    {
                        repeatCounter = 1;
                        break;
                    }
                }
            }

            for (int i = 0; i < maxCounter; i++)
            {
                Console.Write(repeatIndex + " ");
            }
        }
    }
}
