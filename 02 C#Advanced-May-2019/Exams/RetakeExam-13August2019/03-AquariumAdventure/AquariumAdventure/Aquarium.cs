using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        List<Fish> fishInPool;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }

        public Aquarium(string name, int capacity, int size)
        {
            Name = name;
            Capacity = capacity;
            Size = size;

            fishInPool = new List<Fish>();
        }

        public void Add(Fish fish)
        {
            if (Capacity > 0)
            {
                //bool isFishExist = false;

                //foreach (var currentFish in fishInPool)
                //{
                //    if (currentFish.Name == fish.Name)
                //    {
                //        isFishExist = true;
                //    }
                //}

                //if (!isFishExist)
                //{
                //    fishInPool.Add(fish);
                //}

                // Прави същото като горното!

                Fish CurrentFish = fishInPool.FirstOrDefault(x => x.Name == fish.Name);

                if (CurrentFish == null)

                {
                    fishInPool.Add(fish);
                    Capacity--;
                }
            }
        }

        public bool Remove(string name)
        {
            Fish currentFish = fishInPool.FirstOrDefault(x => x.Name == name);

            if (currentFish != null)
            {
                fishInPool.Remove(currentFish);
                Capacity++;
                return true;
            }

            return false;
        }

        public Fish FindFish(string name)
        {
            return fishInPool.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            var aquarium = new StringBuilder();

            aquarium.AppendLine($"Aquarium: {Name} ^ Size: {Size}");

            foreach (var currentFish in fishInPool)
            {
                aquarium.AppendLine(currentFish.ToString());
            }

            return aquarium.ToString().Trim(); // Trim - маха сичко празно!
        }
    }
}
