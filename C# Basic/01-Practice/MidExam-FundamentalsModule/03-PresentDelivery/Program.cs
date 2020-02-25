using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            // Technology Fundamentals Retake Mid Exam - 18 December 2018

            List<int> peopleInHouses = Console.ReadLine().Split("@").Select(int.Parse).ToList();
            int currentSantaIndex = 0;

            while (true)
            {
                string[] jumpAndIndex = Console.ReadLine().Split().ToArray();

                if (jumpAndIndex[0] == "Merry")
                {
                    Console.WriteLine($"Santa's last position was {currentSantaIndex}.");

                    int failedHousesCounter = 0;

                    foreach (var item in peopleInHouses)
                    {
                        if (item != 0)
                        {
                            failedHousesCounter++;
                        }
                    }

                    if (failedHousesCounter == 0)
                    {
                        Console.WriteLine("Mission was successful.");
                    }
                    else
                    {
                        Console.WriteLine($"Santa has failed {failedHousesCounter} houses.");
                    }

                    break;
                }

                int jumpIndex = int.Parse(jumpAndIndex[1]);

                if (currentSantaIndex + jumpIndex <= peopleInHouses.Count - 1)
                {
                    currentSantaIndex += jumpIndex;

                    if (peopleInHouses[currentSantaIndex] == 0)
                    {
                        Console.WriteLine($"House {currentSantaIndex} will have a Merry Christmas.");
                    }
                    else
                    {
                        peopleInHouses[currentSantaIndex] -= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jumpIndex; i++)
                    {
                        if (currentSantaIndex == peopleInHouses.Count - 1)
                        {
                            currentSantaIndex = -1;
                        }
                        currentSantaIndex++;
                    }

                    if (peopleInHouses[currentSantaIndex] == 0)
                    {
                        Console.WriteLine($"House {currentSantaIndex} will have a Merry Christmas.");
                    }
                    else
                    {
                        peopleInHouses[currentSantaIndex] -= 2;
                    }
                }
            }
        }
    }
}
