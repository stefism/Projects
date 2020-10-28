using System;
using System.Collections.Generic;
using System.Linq;

namespace _07AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            //List<string> split = input[0].spli

            List<string> result = new List<string>();


            for (int i = input.Count - 1; i >= 0; i--)
            {
                List<string> split = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int add = 0; add < split.Count; add++)
                {
                    result.Add(split[add]);
                }
            }

            Console.WriteLine(string.Join(" ", result));

            

        }
    }
}
