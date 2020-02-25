using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Legendary_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            var keymaterials = new Dictionary<string, int>();
            keymaterials["motes"] = 0; keymaterials["fragments"] = 0; keymaterials["shards"] = 0;

            var junkMaterials = new Dictionary<string, int>();

            bool isBreaked = false;

            while (true)
            {
                string[] materials = Console.ReadLine().ToLower().Split();
                
                for (int i = 0; i < materials.Length; i += 2)
                {
                    int quantity = int.Parse(materials[i]);
                    string type = materials[i+1];

                    if (type == "motes")
                    {
                        keymaterials[type] += quantity;

                        if (keymaterials[type] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            keymaterials[type] -= 250;
                            isBreaked = true;
                            break;
                        }
                    }

                    else if (type == "fragments")
                    {
                        keymaterials[type] += quantity;

                        if (keymaterials[type] >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            keymaterials[type] -= 250;
                            isBreaked = true;
                            break;
                        }
                    }

                    else if (type == "shards")
                    {
                        keymaterials[type] += quantity;

                        if (keymaterials[type] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            keymaterials[type] -= 250;
                            isBreaked = true;
                            break;
                        }
                    }

                    else
                    {
                        if (!junkMaterials.ContainsKey(type))
                        {
                            junkMaterials[type] = 0;
                        }

                        junkMaterials[type] += quantity;
                    }
                }

                if (isBreaked)
                {
                    break;
                }
            }

            keymaterials = keymaterials.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            junkMaterials = junkMaterials.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in keymaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junkMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
