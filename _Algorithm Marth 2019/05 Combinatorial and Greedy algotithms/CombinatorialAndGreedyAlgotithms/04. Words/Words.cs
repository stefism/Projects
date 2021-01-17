using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Words
{
    class Words // Решава се с алгоритъм за пермутация с повторение.
    {
        private static char[] elements;
        
        private static int count;

        static void Gen(int index)
        {
            if (index >= elements.Length)
            {
                for (int i = 1; i < elements.Length; i++)
                {
                    if (elements[i] == elements[i - 1])
                    {
                        return;
                    }
                }

                count++;
            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Gen(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        static void Swap(int firstIndex, int secondIndex)
        {
            var temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            elements = input.ToCharArray();

            bool unique = input.Distinct().Count() == input.Length;
            //Ако имаме само уникални символи, пермутацията е N! (N фактуриел) и не е нужно да се върти рекурсията. Прави се с цел оптимизация на бързодействието.
            
            if (unique)
            {
                count = 1;
                for (int i = 1; i <= input.Length; i++) //пишем <=  защото сме от N фактуриел или  length-а е равно на N.
                {
                    count *= i;
                }
            }
            else
            {
                Gen(0);
            }
          
            Console.WriteLine(count);
        }
    }
}
