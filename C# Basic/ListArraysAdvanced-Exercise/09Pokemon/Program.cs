using System;
using System.Collections.Generic;
using System.Linq;

namespace _09Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int sum = 0;

            int blowIndex = 0;

            while (input.Count != 0)
            {
                int indexToBlow = int.Parse(Console.ReadLine());

                //sum += input[indexToBlow];

                //int blowIndex = input[indexToBlow];

                if (indexToBlow > input.Count-1 || indexToBlow < 0)
                {
                    int lastIndex = input[input.Count - 1];
                    input.RemoveAt(input.Count - 1);
                    input.Add(lastIndex);
                    sum += lastIndex;

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (lastIndex >= input[i])
                        {
                            input[i] += lastIndex;
                        }
                        else if (lastIndex < input[i])
                        {
                            input[i] -= lastIndex;
                        }
                        //sum += lastIndex;
                        continue;
                    }
                }
                else
                {
                    blowIndex = input[indexToBlow];
                    sum += blowIndex;
                    input.RemoveAt(indexToBlow);

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (blowIndex >= input[i])
                        {
                            input[i] += blowIndex;
                        }
                        else if (blowIndex < input[i])
                        {
                            input[i] -= blowIndex;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
