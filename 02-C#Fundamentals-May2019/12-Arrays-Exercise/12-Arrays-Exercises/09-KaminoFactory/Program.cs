using System;
using System.Linq;

namespace _09_KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequences = int.Parse(Console.ReadLine());
            int sequencesCounter = 0;
            int inputCounter = 0;
            int[] bestDna = new int[sequences];

            int currentStartIndex = 0;
            int currentBestStartIndex = 0;

            while (true)
            {
                string[] inputSequences = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (inputSequences[0] == "Clone them")
                {
                    Console.WriteLine($"Best DNA sample {sequencesCounter} with sum: {bestDna.Sum()}.");
                    Console.WriteLine(string.Join(" ", bestDna));
                    break;
                }
                else
                {
                    inputCounter++;
                    int[] currentDna = new int[sequences];

                    for (int i = 0; i < sequences; i++)
                    {
                        int currentDnaNumber = int.Parse(inputSequences[i]);
                        currentDna[i] = currentDnaNumber;
                    }

                    int bestDnaSum = bestDna.Sum();
                    int currenrDnaSum = currentDna.Sum();

                    int currentDnaSeuqence = CalculateSequence(currentDna);
                    int currentBestDnaSequence = CalculateSequence(bestDna);

                    if (currentDnaSeuqence > currentBestDnaSequence)
                    {
                        bestDna = currentDna;
                        sequencesCounter++;
                    }

                    else if (currentDnaSeuqence == currentBestDnaSequence)
                    {
                        currentStartIndex = CalculateStartIndex(currentDna);
                        currentBestStartIndex = CalculateStartIndex(bestDna);

                        if (currentStartIndex < currentBestStartIndex)
                        {
                            bestDna = currentDna;
                            sequencesCounter++;
                        }
                    }

                    if (currentDnaSeuqence == currentBestDnaSequence && currentStartIndex == currentBestStartIndex)
                    {
                        if (currenrDnaSum > bestDnaSum)
                        {
                            bestDna = currentDna;
                            sequencesCounter++;
                        }
                    }
                 }
            }
        }

        static int CalculateSequence (int[] input)
        {
            int sequenceCounter = 1;
            int maxCounter = 0;
            int startInex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i+1; j < input.Length; j++)
                {
                    if (input[i] != 1)
                    {
                        break;
                    }
                    else
                    {
                        if (input[j] == input[i])
                        {
                            sequenceCounter++;
                            startInex = i;
                            if (sequenceCounter > maxCounter)
                            {
                                maxCounter = sequenceCounter;
                            }
                        }
                        else
                        {
                            sequenceCounter = 1;
                            break;
                        }
                    }
                }
            }

            return maxCounter;
        }

        static int CalculateStartIndex(int[] input)
        {
            int sequenceCounter = 1;
            int maxCounter = 0;
            int startInex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] != 1)
                    {
                        break;
                    }
                    else
                    {
                        if (input[j] == input[i])
                        {
                            sequenceCounter++;
                            //startInex = i;
                            if (sequenceCounter > maxCounter)
                            {
                                maxCounter = sequenceCounter;
                                startInex = i;
                            }
                        }
                        else
                        {
                            sequenceCounter = 1;
                            break;
                        }
                    }
                }
            }

            return startInex;
        }
    }
}
