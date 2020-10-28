using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            while (true)
            {
                string[] currentCar = Console.ReadLine().Split(", ");

                string command = currentCar[0];

                if (command == "END")
                {
                    break;
                }

                string carNumber = currentCar[1];

                if (command == "IN")
                {
                    cars.Add(carNumber);
                }

                else if (command == "OUT")
                {
                    cars.Remove(carNumber);
                }
            }

            if (cars.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
