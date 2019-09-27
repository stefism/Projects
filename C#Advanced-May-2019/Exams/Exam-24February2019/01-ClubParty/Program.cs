using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());
            Stack<string> hall = new Stack<string>(Console.ReadLine().Split());

            var halls = new Dictionary<string, List<int>>();

            string currentOpenHall = string.Empty;

            bool isOpenHall = false;

            while (true)
            {
                if (hall.Count == 0)
                {
                    break;
                }

                string currentItem = hall.Pop();

                bool isNumber = int.TryParse(currentItem, out int peopleNumber);

                if (isNumber && !isOpenHall)
                {
                    continue;
                }

                if (!isNumber && !isOpenHall)
                {
                    halls[currentItem] = new List<int>();
                    isOpenHall = true;
                    currentOpenHall = currentItem;
                    continue;
                }

                if (!isNumber && isOpenHall)
                {
                    halls[currentItem] = new List<int>();
                    continue;
                }

                if (isNumber && isOpenHall)
                {
                    if (peopleNumber <= hallCapacity
                        && (halls[currentOpenHall].Sum() + peopleNumber <= hallCapacity))
                    {
                        halls[currentOpenHall].Add(peopleNumber);
                    }
                    else
                    {
                        var closedHall = halls.FirstOrDefault(x => x.Key == currentOpenHall);

                        Console.WriteLine($"{closedHall.Key} -> {string.Join(", ", closedHall.Value)}");

                        halls.Remove(closedHall.Key);

                        if (halls.Count > 0)
                        {
                            var newOpenHall = halls.First();

                            currentOpenHall = newOpenHall.Key;

                            if (peopleNumber <= hallCapacity
                            && halls[currentOpenHall].Sum() + peopleNumber <= hallCapacity)
                            {
                                halls[currentOpenHall].Add(peopleNumber);
                            }
                        }
                        else
                        {
                            isOpenHall = false;
                        }
                    }
                }
            }
        }
    }
}
