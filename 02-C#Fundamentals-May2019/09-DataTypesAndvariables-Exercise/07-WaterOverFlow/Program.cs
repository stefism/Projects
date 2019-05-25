using System;

namespace _07_WaterOverFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int waterTankCapacity = 255;
            int currentTankCapacity = 0;

            int substractTimes = int.Parse(Console.ReadLine());

            for (int i = 0; i < substractTimes; i++)
            {
                int pourLiters = int.Parse(Console.ReadLine());

                currentTankCapacity += pourLiters;

                if (currentTankCapacity > waterTankCapacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    currentTankCapacity -= pourLiters;
                }
            }

            Console.WriteLine(currentTankCapacity);
        }
    }
}
