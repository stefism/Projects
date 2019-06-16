using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputString = Console.ReadLine().Split().ToList();
            int index1 = 0;
            int index2 = 0;

            while (true)
            {
                List<string> currentCommands = Console.ReadLine().Split().ToList();

                string command = currentCommands[0];

                if (currentCommands.Count > 1)
                {
                    index1 = int.Parse(currentCommands[1]);
                    index2 = int.Parse(currentCommands[2]);
                }
               
                if (command == "merge")
                {
                    if (index1 < 0)
                    {
                        index1 = 0;
                    }

                    if (index2 > inputString.Count - 1)
                    {
                        index2 = inputString.Count - 1;
                    }

                    for (int i = index1+1; i <= index2; i++)
                    {
                        inputString[index1] += inputString[i];
                    }

                    for (int i = 0; i < index2 - index1; i++)
                    {
                        inputString.RemoveAt(index1 + 1);
                    }
                }

                else if (command == "divide")
                {
                    string divideString = inputString[index1];
                    int charInPartition = divideString.Length / index2;

                    List<string> newPartitions = new List<string>();
                    int divideCounter = 0;

                    for (int i = 0; i < index2; i++)
                    {
                        string currentNewPartition = string.Empty;

                        for (int j = 0; j < charInPartition; j++)
                        {
                            currentNewPartition += divideString[divideCounter];
                            divideCounter++;
                        }
                        newPartitions.Add(currentNewPartition);
                    }

                    if (divideString.Length/charInPartition > newPartitions.Count) 
                    {
                        for (int i = divideCounter; i < divideString.Length; i++)  // int i = newPartitions.Count; i < divideString.Length; i++
                        {
                            newPartitions[newPartitions.Count - 1] += divideString[i];
                        }
                    }

                    inputString.RemoveAt(index1);
                    inputString.InsertRange(index1, newPartitions);
                }

                else if (command == "3:1")
                {
                    Console.WriteLine(string.Join(" ", inputString));
                    break;
                }
            }
        }
    }
}
