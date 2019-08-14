using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());

            int racks = 1;
            int currentCapacity = rackCapacity;

            if (rackCapacity == 0)
            {
                Console.WriteLine(clothes.Count);
                return;
            }

            while (clothes.Count != 0)
            {
                int currentCloth = clothes.Pop();

                if (currentCapacity > currentCloth)
                {
                    currentCapacity -= currentCloth;
                    continue;
                }

                if (currentCapacity < currentCloth)
                {
                    racks++;
                    currentCapacity = rackCapacity;
                    clothes.Push(currentCloth);
                }

                else if (currentCapacity == currentCloth && clothes.Count > 0)
                {
                    racks++;
                    currentCapacity = rackCapacity;
                    //clothes.Push(currentCloth);
                }
            }

            Console.WriteLine(racks);
        }
    }
}
