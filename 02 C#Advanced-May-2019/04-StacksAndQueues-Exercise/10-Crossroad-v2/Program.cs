using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_Crossroad_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int initialGreenLight = greenLight;

            Queue<string> waitingCars = new Queue<string>();

            int passedCarsCount = 0;

            //bool isSave = true;

            while (true)
            {
                string car = Console.ReadLine();

                if (car == "END")
                {
                    break;
                }

                if (car != "green")
                {
                    waitingCars.Enqueue(car);
                }

                else
                {
                    greenLight = initialGreenLight;

                    while (waitingCars.Count > 0)
                    {
                        string currentCar = waitingCars.Dequeue();

                        if (currentCar.Length < greenLight)
                        {
                            passedCarsCount++;

                            if (freeWindow == 0)
                            {
                                break;
                            }

                            greenLight -= currentCar.Length;

                            continue;
                        }
                        else
                        {
                            //greenLight -= currentCar.Length;

                            if (greenLight <= 0)
                            {
                                waitingCars.Enqueue(currentCar);
                                break;
                            }
                            else
                            {
                                if (currentCar.Length <= freeWindow + greenLight) //  if (currentCar.Length < freeWindow) - не работи.
                                {
                                    passedCarsCount++;
                                    break;
                                    //continue;
                                }
                                else
                                {
                                    Console.WriteLine("A crash happened!");

                                    int crashIndex = freeWindow + greenLight;

                                    if (crashIndex > currentCar.Length-1)
                                    {
                                        crashIndex = freeWindow;
                                    }

                                    Console.WriteLine($"{currentCar} was hit at {currentCar[crashIndex]}.");
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
        }
    }
}
