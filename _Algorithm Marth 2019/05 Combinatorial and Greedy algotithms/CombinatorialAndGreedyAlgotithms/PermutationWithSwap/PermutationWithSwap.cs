using System;

namespace PermutationWithSwap
{
    class PermutationWithSwap
    {
        static int[] elements;        
        static void Permute(int index) // index - current cell to fill
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                Permute(index + 1);
                for (int i = index + 1; i < elements.Length; i++) // Започва от index + 1 за да имаме поне 2ма, които да свапнеме. Иначе като стигне до края, няма да има с какво да свапне.
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }
        }

        static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        static void Main(string[] args)
        {
            elements = new[] { 1, 2, 3 };          

            Permute(0);
        }
    }
}
