using System;

namespace _03._Generating_0_1_Vectors
{
    class Generating0_1Vectors
    {
        static void Generate(int index, int[] array)
        {
            if (index == array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    array[index] = i;
                    Generate(index + 1, array);
                }
            }

            /*
                0 0 0 0 0 0 0 0
                0 0 0 0 0 0 0 1
                0 0 0 0 0 0 1 0
                0 0 0 0 0 0 1 1
                0 0 0 0 0 1 0 0
                0 0 0 0 0 1 0 1
                0 0 0 0 0 1 1 0
                0 0 0 0 0 1 1 1
             */
        }

        static void Main(string[] args)
        {
            var array = new int[8];
            Generate(0, array);
        }
    }
}
