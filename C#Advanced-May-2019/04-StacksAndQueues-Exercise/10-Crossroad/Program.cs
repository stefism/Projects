using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_Crossroad
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> waitingCars = new Queue<string>();

            int passedCarsCount = 0;

            bool isSave = true;

            while (true)
            {
                if (!isSave)
                {
                    break;
                }

                string cars = Console.ReadLine();

                if (cars == "END")
                {
                    break;
                }

                isSave = true;

                if (cars == "green")
                {
                    while (waitingCars.Count != 0)
                    {
                        string carToPass = waitingCars.Dequeue();

                        if (carToPass.Length < greenLight)
                        {
                            passedCarsCount++;
                            greenLight -= carToPass.Length;

                            if (greenLight > 0)
                            {
                                continue;
                            }
                            else
                            {
                                CalculatePassedCars(greenLight, freeWindow, waitingCars, ref passedCarsCount, ref isSave, ref carToPass);
                            }
                        }
                        else
                        {
                            CalculatePassedCars(greenLight, freeWindow, waitingCars, ref passedCarsCount, ref isSave, ref carToPass);
                        }
                    }
                }

                else
                {
                    waitingCars.Enqueue(cars);
                }
            }

            if (isSave)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
            }
        }

        private static void CalculatePassedCars(int greenLight, int freeWindow, Queue<string> waitingCars, ref int passedCarsCount, ref bool isSave, ref string carToPass)
        {
            if (waitingCars.Count > 0)
            {
                int secondLeft = greenLight - carToPass.Length;

                while (secondLeft != 0)
                {
                    if (!isSave)
                    {
                        break;
                    }

                    carToPass = waitingCars.Dequeue();

                    if (carToPass.Length < secondLeft)
                    {
                        passedCarsCount++;
                        secondLeft -= carToPass.Length;
                    }
                    else
                    {
                        if (carToPass.Length - secondLeft < freeWindow)
                        {
                            passedCarsCount++;
                            break;
                        }
                        else
                        {
                            char indexToHit = carToPass[carToPass.Length - secondLeft - 1];

                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{carToPass} was hit at {indexToHit}.");
                            isSave = false;
                            break;
                        }
                    }
                }
            }
        }
    }
}
