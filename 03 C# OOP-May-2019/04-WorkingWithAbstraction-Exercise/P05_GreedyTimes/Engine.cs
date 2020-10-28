using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Engine
    {
        public Engine()
        {
            bag = new Dictionary<string, Dictionary<string, long>>();
        }

        private Dictionary<string, Dictionary<string, long>> bag;
        private long gold;
        private long gem;
        private long cashMoney;
        private string itemType;
        private string name;
        private long item;

        public void Run()
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < items.Length; i += 2)
            {
                name = items[i];
                item = long.Parse(items[i + 1]);

                DefineItemType(name);

                if (itemType == "")
                {
                    continue;
                }
                else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + item)
                {
                    continue;
                }

                bool isBagContainsKey = bag.ContainsKey(itemType);
                
                switch (itemType)
                {
                    
                    case "Gem":
                        if (!isBagContainsKey)
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (item > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[itemType].Values.Sum() + item > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;

                    case "Cash":
                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (item > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }

                        else if (bag[itemType].Values.Sum() + item > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }

                        break;
                }

                AddItemsToBag(name, item);
            }

            PrintItem();
        }

        private void PrintItem()
        {
            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
                foreach (var currrentItem in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{currrentItem.Key} - {currrentItem.Value}");
                }
            }
        }

        private void AddItemsToBag(string name, long item)
        {
            if (!bag.ContainsKey(itemType))
            {
                bag[itemType] = new Dictionary<string, long>();
            }

            if (!bag[itemType].ContainsKey(name))
            {
                bag[itemType][name] = 0;
            }

            bag[itemType][name] += item;
            if (itemType == "Gold")
            {
                gold += item;
            }
            else if (itemType == "Gem")
            {
                gem += item;
            }
            else if (itemType == "Cash")
            {
                cashMoney += item;
            }
        }

        private void DefineItemType(string name)
        {
            if (name.Length == 3)
            {
                itemType = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                itemType = "Gold";
            }
        }
    }
}
