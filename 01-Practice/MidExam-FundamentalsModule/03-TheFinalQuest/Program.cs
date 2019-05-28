using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Technology Fundamentals Mid Exam - 10 March 2019 Group 2

            List<string> input = Console.ReadLine().Split().ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                string currentCommand = commands[0];

                switch (currentCommand)
                {
                    case "Delete":
                        int index = int.Parse(commands[1]);
                        if (index >=0 && index <= input.Count-2)
                        {
                            input.RemoveAt(index+1);
                        }
                        break;

                    case "Swap":
                        if (input.Contains(commands[1]) && input.Contains(commands[2]))
                        {
                            int word1Index = input.IndexOf(commands[1]);
                            int word2Index = input.IndexOf(commands[2]);
                            string word1 = input[word1Index];
                            string word2 = input[word2Index];

                            input[word1Index] = word2;
                            input[word2Index] = word1;
                        }
                        break;

                    case "Put":
                        int indexB = int.Parse(commands[2]);
                        if (indexB >=1 && indexB <= input.Count+1) //В case "Put" проверката трябва да е if (indexB >=1 && indexB <= input.Count + 1).
                        { // Беше if (indexB >=1 && indexB <= input.Count-1)
                            input.Insert(indexB-1, commands[1]); // ?? Тука да направиме евентуално проверка, ако индекса е нула да не е минус 1
                        }
                        break;

                    case "Sort":
                        input.Sort((a, b) => b.CompareTo(a)); // descending order
                        break;

                    case "Replace":
                        input = input.Select(str => str.Replace(commands[2], commands[1])).ToList(); // Замества само ако съществува.
                        break;

                    case "Stop":
                        Console.WriteLine(string.Join(" ", input));
                        return;
                }
            }
        }
    }
}
