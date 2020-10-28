using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        public int Count { get; set; }

        //public int Count
        //{
        //    get { return allCars.Count; }
        //} // Така трябва да работи автоматично.

        private List<Car> allCars;

        public Parking(int capacity) : this()
        {
            this.capacity = capacity;
        }

        public Parking()
        {
            allCars = new List<Car>();
            Count = 0;
        }

        public string AddCar(Car car)
        {

            foreach (var currentCar in allCars)
            {
                if (currentCar.RegistrationNumber == car.RegistrationNumber)
                {
                    return "Car with that registration number, already exists!";
                }
            }

            if (allCars.Count == capacity)
            {
                return "Parking is full!";
            }

            allCars.Add(car);
            Count++;
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            foreach (var currentCar in allCars)
            {
                if (currentCar.RegistrationNumber == registrationNumber)
                {
                    allCars.Remove(currentCar);
                    Count--;
                    return $"Successfully removed {registrationNumber}";
                }
            }

            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber)
        {
            foreach (var currentCar in allCars)
            {
                if (currentCar.RegistrationNumber == registrationNumber)
                {
                    return currentCar;
                }
            }

            return null;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < allCars.Count; i++)
            {
                if (registrationNumbers.Contains(allCars[i].RegistrationNumber))
                {
                    string currentRegNumber = allCars[i].RegistrationNumber;
                    allCars.Remove(allCars[i]);
                    //registrationNumbers.Remove(currentRegNumber);
                    i--;
                    Count--;
                    Console.WriteLine($"Successfully removed {currentRegNumber}");
                }

                //if (registrationNumbers.Count > 0)
                //{
                //    foreach (var number in registrationNumbers)
                //    {
                //        Console.WriteLine("Car with that registration number, doesn't exist!");
                //    }
                //}
            }
        }
    }
}
