using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_BorderControl
{
    class StartUp
    {
        static Resident resident;

        public static void Main()
        {
            List<Resident> residents = new List<Resident>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                string nameOrModel = input[0];

                if (input.Length == 3)
                {
                    int age = int.Parse(input[1]);
                    string id = input[2];

                    resident = new Resident(nameOrModel, age, id);
                }
                else
                {
                    string id = input[1];
                    resident = new Resident(nameOrModel, id);
                }

                residents.Add(resident);
            }

            string fakeId = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, residents
                .Where(x => x.Id.EndsWith(fakeId))));
        }
    }
}
