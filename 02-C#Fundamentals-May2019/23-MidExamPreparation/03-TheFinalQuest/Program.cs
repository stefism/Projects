using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] currentCommands = input.Split();
                string command = currentCommands[0];

                switch (command)
                {
                    case "Delete":
                        int index = int.Parse(currentCommands[1]) + 1;

                        if (index >= 0 && index < words.Count)
                        {
                            words.RemoveAt(index);
                        }
                        break;

                    case "Swap":
                        string firstWord = currentCommands[1];
                        string secondWord = currentCommands[2];

                        if (words.Contains(firstWord) && words.Contains(secondWord))
                        {
                            int firstWordIndex = words.IndexOf(firstWord);
                            int secondWordIndex = words.IndexOf(secondWord);

                            words[firstWordIndex] = secondWord;
                            words[secondWordIndex] = firstWord;
                        }
                        break;

                    case "Put":
                        string word = currentCommands[1];
                        index = int.Parse(currentCommands[2]) - 1;

                        if (index >= 0 && index <=  words.Count)
                        {
                            words.Insert(index, word);
                        }
                        break;

                    case "Sort":
                        words.Sort();
                        words.Reverse();
                        //words = words.OrderByDescending(x => x).ToList();
                        break;

                    case "Replace":
                        firstWord = currentCommands[1];
                        secondWord = currentCommands[2];

                        if (words.Contains(secondWord))
                        {
                            int secondWordIndex = words.IndexOf(secondWord);
                            words[secondWordIndex] = firstWord;
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
