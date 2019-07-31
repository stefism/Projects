using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_OnTheWayToAnnapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            // Technology Fundamentals Final Exam -14 April 2019 Group I

            var storeDictionary = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split("->");

                if (input[0] == "END")
                {
                    break;
                }

                string command = input[0];
                string storeName = input[1];
                
                if (command == "Add")
                {
                    string item = input[2];

                    if (!storeDictionary.ContainsKey(storeName))
                    {
                        storeDictionary[storeName] = new List<string>();
                    }

                    foreach (var singleStore in storeDictionary)
                    {
                        if (singleStore.Key == storeName)
                        {
                            string[] items = item.Split(",");

                            if (items.Length == 1)
                            {
                                storeDictionary[storeName].Add(items[0]);
                            }
                            else
                            {
                                foreach (var storeProduct in items)
                                {
                                    storeDictionary[storeName].Add(storeProduct);
                                }
                            }
                        }
                    }
                }

                else if (command == "Remove")
                {
                    foreach (var singleStore in storeDictionary)
                    {
                        if (singleStore.Key == storeName)
                        {
                            storeDictionary.Remove(storeName);
                            break;
                        }
                    }
                }
            }

            storeDictionary = storeDictionary.OrderByDescending(x => x.Value.Count)
                .ThenByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Stores list:");

            foreach (var item in storeDictionary)
            {
                Console.WriteLine(item.Key);

                Console.WriteLine(string.Join(Environment.NewLine, item.Value
                    .Select(x => $"<<{x}>>")));
            }
        }
    }
}
