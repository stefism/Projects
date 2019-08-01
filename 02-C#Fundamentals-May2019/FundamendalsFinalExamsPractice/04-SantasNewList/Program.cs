using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_SantasNewList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Programming FundamentaAdditional Retake Exam - 10 January 2019 Part II

            var children = new Dictionary<string, int>();
            var toys = new Dictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split("->");

                if (input[0] == "END")
                {
                    break;
                }

                string childName = input[0];
                string toysName = input[1];
                int toysCount = 0;

                if (input[0] != "Remove")
                {
                    toysCount = int.Parse(input[2]);
                }
                else
                {
                    childName = input[1];
                    children.Remove(childName);
                    continue;
                }

                if (!children.ContainsKey(childName))
                {
                    children[childName] = 0;
                }

                children[childName] += toysCount;

                if (!toys.ContainsKey(toysName))
                {
                    toys[toysName] = 0;
                }

                toys[toysName] += toysCount;
            }

            Console.WriteLine("Children:");

            Console.WriteLine(string.Join(Environment.NewLine, children
                .OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                .Select(x => $"{x.Key} -> {x.Value}")));

            Console.WriteLine("Presents:");

            Console.WriteLine(string.Join(Environment.NewLine, toys
                .Select(x => $"{x.Key} -> {x.Value}")));
        }
    }
}
