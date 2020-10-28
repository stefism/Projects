using System;
using System.Linq;
using System.Collections.Generic;

namespace _01_DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> males = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> females = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int currMale = males.Peek();
                int currFemale = females.Peek();

                if (currMale <= 0 || currFemale <= 0)
                {
                    if (currMale <= 0)
                    {
                        males.Pop();
                    }
                    if (currFemale <= 0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }

                if (currMale % 25 == 0 || currFemale % 25 == 0)
                {
                    if (currMale % 25 == 0)
                    {
                        males.Pop();
                        males.Pop();
                    }

                    if (currFemale % 25 == 0)
                    {
                        females.Dequeue();
                        females.Dequeue();
                    }

                    continue;
                }

                currMale = males.Pop();
                currFemale = females.Dequeue();

                if (currMale == currFemale)
                {
                    matches++;
                }
                else
                {
                    currMale -= 2;
                    males.Push(currMale);
                }
            }

            Console.WriteLine($"Matches: {matches}");

            if (males.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }

            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
        }
    }
}
