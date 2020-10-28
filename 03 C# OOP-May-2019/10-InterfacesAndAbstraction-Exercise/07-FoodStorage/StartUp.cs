using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _05_BorderControl
{
    public class StartUp
    {
        static List<Resident> residents;

        public static void Main()
        {
            residents = new List<Resident>();

            int numberOfResident = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfResident; i++)
            {
                string[] input = Console.ReadLine().Split();

                string residentName = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    BigInteger id = BigInteger.Parse(input[2]);
                    string birthdate = input[3];

                    Resident resident = new Resident(residentName, birthdate, age, id);
                    residents.Add(resident);
                }
                else
                {
                    string group = input[2];

                    Resident rebel = new Rebel(residentName, age, group);
                    residents.Add(rebel);
                }
            }
            int totalFood = 0;

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                string residentName = input[0];

                Resident resident = residents.FirstOrDefault(x => x.Name == residentName);

                if (resident != null)
                {
                    string residentType = resident.GetType().Name;

                    if (residentType == "Rebel")
                    {
                        resident.BuyFood(5);
                    }
                    else
                    {
                        resident.BuyFood(10);
                    }

                    totalFood += resident.Food;
                }
            }

            Console.WriteLine(totalFood);
        }
    }
}
