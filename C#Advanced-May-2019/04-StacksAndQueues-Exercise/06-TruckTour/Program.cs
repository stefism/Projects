using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int gasStation = int.Parse(Console.ReadLine());

            Queue<int[]> petrolPumps = new Queue<int[]>();

            for (int i = 0; i < gasStation; i++)
            {
                int[] fuelInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

                petrolPumps.Enqueue(fuelInfo);
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var petrolPump in petrolPumps)
                {
                    int petrolAmount = petrolPump[0];
                    int distance = petrolPump[1];

                    totalFuel += petrolAmount - distance;

                    if (totalFuel < 0)
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        index++;
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
