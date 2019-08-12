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

            string cars;

            bool isSave = true;

            while ((cars = Console.ReadLine()) != "END")
            {
                isSave = true;

                if (cars == "green")
                {
                    string carToPass = waitingCars.Dequeue();

                    if (carToPass.Length < greenLight)
                    {
                        passedCarsCount++;

                        int secondLeft = greenLight - carToPass.Length;

                        while (secondLeft != 0)
                        {
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
                                }
                                else
                                {
                                    char indexToHit = carToPass[carToPass.Length - secondLeft];

                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{carToPass} was hit at {indexToHit}");
                                    isSave = false;
                                    break;
                                }
                            }
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
                Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
            }
        }
    }
}
