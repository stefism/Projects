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

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                string residentType = input[0];
                string residentName = input[1];

                switch (residentType)
                {
                    case "Citizen":
                        int age = int.Parse(input[2]);
                        BigInteger id = BigInteger.Parse(input[3]);
                        string birthdate = input[4];

                        Resident resident = new Resident(residentName, birthdate, age, id);
                        residents.Add(resident);
                        break;

                    case"Pet":
                        birthdate = input[2];
                        Resident pet = new Pet(residentName, birthdate);
                        residents.Add(pet);
                        break;

                    case "Robot":
                        id = BigInteger.Parse(input[2]);
                        Resident robot = new Robot(residentName, id);
                        residents.Add(robot);
                        break;
                }
            }

            string year = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, residents
                .Where(x => x.Birthdate != null)
                .Where(x => x.Birthdate.EndsWith(year))));
        }
    }
}
