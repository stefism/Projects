using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> array1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> array2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> combunedArray = new List<int>();

            int maxArrayLength = 0;
            int minArrayLength = 0;


            //Console.WriteLine(array1.Count);

            if (array1.Count > array2.Count)
            {
                maxArrayLength = array1.Count;
                minArrayLength = array2.Count;
            }
            else
            {
                maxArrayLength = array2.Count;
                minArrayLength = array1.Count;
            }

            for (int i = 0; i < maxArrayLength; i++)
            {
                if (i < minArrayLength)
                {
                    combunedArray.Add(array1[i]);
                    combunedArray.Add(array2[i]);
                }
                else
                {
                    if (array1.Count == minArrayLength)
                    {
                        combunedArray.Add(array2[i]);
                    }
                    else
                    {
                        combunedArray.Add(array1[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", combunedArray));
        }
    }
}
