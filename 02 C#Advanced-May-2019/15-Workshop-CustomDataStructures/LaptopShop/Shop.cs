using System;
using System.Collections.Generic;
using System.Text;

namespace LaptopShop
{
    public class Shop
    {
        private Dictionary<string, List<Laptop>> laptopsDictionary;

        public Shop()
        {
            laptopsDictionary = new Dictionary<string, List<Laptop>>();
        }

        public int count => laptopsDictionary.Count;

        public void AddLaptop(Laptop laptop)
        {
            IfNullThrowException(laptop);

            if (!laptopsDictionary.ContainsKey(laptop.Make))
            {
                laptopsDictionary[laptop.Make] = new List<Laptop>();
            }

            laptopsDictionary[laptop.Make].Add(laptop);
        }

        public bool RemoveLaptop(Laptop laptop)
        {
            IfNullThrowException(laptop);

            if (!laptopsDictionary.ContainsKey(laptop.Make))
            {
                return false;
            }

            if (!laptopsDictionary[laptop.Make].Contains(laptop))
            {
                return false;
            }

            laptopsDictionary[laptop.Make].Remove(laptop);

            if (laptopsDictionary[laptop.Make].Count == 0)
            {
                laptopsDictionary.Remove(laptop.Make);
            }

            return true;
        }

        public bool ContainsLaptop(Laptop laptop)
        {
            IfNullThrowException(laptop);

            if (!laptopsDictionary.ContainsKey(laptop.Make))
            {
                return false;
            }

            if (laptopsDictionary[laptop.Make].Contains(laptop))
            {
                return false;
            }

            return true;
        }

        public void PrintAllLaptops(Action<Laptop> action)
        {
            foreach (var (make, dictLaptop) in laptopsDictionary)
            {
                foreach (var laptop in dictLaptop)
                {
                    action(laptop);
                }
            }
        }

        private static void IfNullThrowException(Laptop laptop)
        {
            if (laptop == null)
            {
                throw new ArgumentNullException(nameof(laptop), "Object cannot be null!");
            }
        }
    }
}
