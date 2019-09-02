using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car1 = new Car("Skoda", "Fabia", 120, "CB1260AB");
            Car car2 = new Car("Opel", "Vectra", 140, "CA1281AC");
            Car car3 = new Car("BMW", "S4", 230, "CB4444AC");
            Car car4 = new Car("Porshe", "911", 300, "OO1281AC");
            Car car5 = new Car("Audi", "A8", 225, "AA5566YY");
            Car car6 = new Car("Mercedes", "S800", 140, "CM6623MC");

            Parking parking = new Parking(10);

            parking.AddCar(car1);
            parking.AddCar(car1);
            parking.AddCar(car2);
            System.Console.WriteLine(parking.GetCar("CB1260AB"));
            //System.Console.WriteLine(parking.Count);
            //System.Console.WriteLine(car1.ToString());
            //parking.RemoveCar("CA1281AC");
            //System.Console.WriteLine(parking.Count);
            //parking.RemoveCar("CA1281AC");
            parking.AddCar(car3);
            parking.AddCar(car4);
            parking.AddCar(car5);
            parking.AddCar(car6);
            System.Console.WriteLine(parking.Count);
            List<string> regNumbers = new List<string>();
            regNumbers.Add("CM6623MC");
            regNumbers.Add("AA5566YY");

            parking.RemoveSetOfRegistrationNumber(regNumbers);
            System.Console.WriteLine(parking.Count);
            System.Console.WriteLine(parking.AddCar(car6));

        }
    }
}
