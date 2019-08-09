using System;
using System.Linq;
using System.Collections.Generic;

namespace _06_TrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int carToPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int passedCarsCount = 0;

            while (true)
            {
                string currentCar = Console.ReadLine();

                if (currentCar == "end")
                {
                    Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
                    break;
                }

                if (currentCar == "green")
                {
                    for (int i = 0; i < carToPass; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        passedCarsCount++;
                    }
                }
                else
                {
                cars.Enqueue(currentCar);
                }
            }
        }
    }
}
