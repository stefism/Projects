using System;

namespace Variations
{
    class Variation
    {
        static int[] elements;
        static bool[] used;
        static int[] variations;

        static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variations[index] = elements[i];
                        Variations(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            elements = new[] { 1, 2, 3, 4 };
            variations = new int[2];
            used = new bool[elements.Length];

            Variations(0);
        }
    }
}
