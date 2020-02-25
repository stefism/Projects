using System;
using System.Collections.Generic;
using System.Linq;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int partOfInput = input.Count / 4;
            List<int> topList = new List<int>();
            List<int> bottomList = new List<int>(input);
            //List<int> result = new List<int>();

            for (int left = partOfInput-1; left >= 0; left--)
            {
                topList.Add(input[left]);
                bottomList.RemoveAt(left);
            }

            for (int right = input.Count-1; right >= input.Count-partOfInput; right--)
            {
                topList.Add(input[right]);
                bottomList.RemoveAt(bottomList.Count-1);
            }

            for (int i = 0; i < topList.Count; i++)
            {
                int result = topList[i] + bottomList[i];
                Console.Write(result + " ");
            }
            //Console.WriteLine(string.Join(" ", topList));
            //Console.WriteLine(string.Join(" ", bottomList));

        }
    }
}
