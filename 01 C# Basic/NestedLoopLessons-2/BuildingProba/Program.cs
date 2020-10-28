using System;

namespace BuildingV2
{
    class Program
    {
        static void Main(string[] args)
        {

            int floorsCount = int.Parse(Console.ReadLine());
            int roomsPerFloorCount = int.Parse(Console.ReadLine());

            for (int floorNumber = floorsCount; floorNumber >= 1; floorNumber--)
            {
                for (int roomNumber = 0; roomNumber < roomsPerFloorCount; roomNumber++)
                {

                    if (floorNumber == floorsCount)
                    {
                        Console.Write($"L{floorNumber}{roomNumber} ");
                    }

                    else if (floorNumber % 2 == 0)
                    {
                        Console.Write($"O{floorNumber}{roomNumber} ");
                    }
                    else
                    {
                        Console.Write($"A{floorNumber}{roomNumber} ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
