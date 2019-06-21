using System;
using System.Collections.Generic;
using System.Linq;

namespace _04m_MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> input2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> combinedList = new List<int>();
            List<int> rangeList = new List<int>();
            List<int> result = new List<int>();

            for (int i = 0; i < Math.Min(input1.Count, input2.Count); i++)
            {
                combinedList.Add(input1[i]);
                combinedList.Add(input2[input2.Count - 1 - i]);
            }

            if (input1.Count > input2.Count)
            {
                rangeList.Add(input1[input1.Count - 2]);
                rangeList.Add(input1[input1.Count - 1]);
            }
            else
            {
                rangeList.Add(input2[0]);
                rangeList.Add(input2[1]);
            }

            rangeList.Sort();

            foreach (var item in combinedList)
            {
                if (item > rangeList[0] && item < rangeList[1])
                {
                    result.Add(item);
                }
            }

            result.Sort();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
