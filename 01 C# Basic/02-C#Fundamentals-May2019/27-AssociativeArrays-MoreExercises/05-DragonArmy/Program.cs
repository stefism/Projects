using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            var dragonsDictionary = new Dictionary<string, List<Dragons>>();

            int numbersOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfDragons; i++)
            {
                string[] dragonInfo = Console.ReadLine().Split();

                string type = dragonInfo[0];
                string name = dragonInfo[1];
                bool damageOrNull = int.TryParse(dragonInfo[2], out int damage);
                bool healthOrNull = int.TryParse(dragonInfo[3], out int health);
                bool armorOrNull = int.TryParse(dragonInfo[4], out int armor);

                if (!dragonsDictionary.ContainsKey(type))
                {
                    dragonsDictionary[type] = new List<Dragons>();
                    AddInfoToDictionary(dragonsDictionary, type, name, damageOrNull, damage, healthOrNull, health, armorOrNull, armor);
                }
                else
                {
                    foreach (var dragon in dragonsDictionary)
                    {
                        if (dragon.Key == type)
                        {
                            foreach (var values in dragon.Value)
                            {
                                if (values.Name == name)
                                {
                                    dragonsDictionary[type].Remove(values);
                                    AddInfoToDictionary(dragonsDictionary, type, name, damageOrNull, damage, healthOrNull, health, armorOrNull, armor);
                                    break;
                                }
                                else
                                {
                                    AddInfoToDictionary(dragonsDictionary, type, name, damageOrNull, damage, healthOrNull, health, armorOrNull, armor);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //dragonsDictionary = dragonsDictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value); // Не работи

            //List<Dragons> current = dragonsDictionary.Values;

            foreach (var dragon in dragonsDictionary)
            {
                double averageDamage = dragon.Value.Select(x => x.Damage).Average();
                double averageHealth = dragon.Value.Select(x => x.Health).Average();
                double averageArmor = dragon.Value.Select(x => x.Armor).Average();

                Console.WriteLine($"{dragon.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                List<Dragons> current = dragon.Value;
                current = current.OrderBy(x => x.Name).ToList();

                foreach (var value in current)
                {
                    //List<Dragons> current = value;
                    Console.WriteLine($"-{value.Name} -> damage: {value.Damage}, health: {value.Health}, armor: {value.Armor}");
                    //Console.WriteLine($"-{value.Name} -> damage: {value.Damage}, health: {value.Health}, armor: {value.Armor}");
                }

                //Console.WriteLine(string.Join(Environment.NewLine, dragon.Value.OrderBy(x => x.Name)
                //    .Select(x => $"-{x.Name} -> damage: {x.Damage}, health: {x.Health}, armor: {x.Armor}")));
            }
        }

        private static void AddInfoToDictionary(Dictionary<string, List<Dragons>> dragonsDictionary, string type, string name, bool damageOrNull, int damage, bool healthOrNull, int health, bool armorOrNull, int armor)
        {
            Dragons currentInfo = new Dragons();

            currentInfo.Name = name;

            if (damageOrNull)
            {
                currentInfo.Damage = damage;
            }

            if (healthOrNull)
            {
                currentInfo.Health = health;
            }

            if (armorOrNull)
            {
                currentInfo.Armor = armor;
            }

            dragonsDictionary[type].Add(currentInfo);
        }
    }

    class Dragons
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public Dragons()
        {
            Damage = 45;
            Health = 250;
            Armor = 10;
        }
    }
}
