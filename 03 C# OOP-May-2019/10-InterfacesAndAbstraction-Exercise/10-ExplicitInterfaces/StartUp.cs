using System;

namespace _10_ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                string name = input[0];

                IPerson person = new Citizen(name);
                Citizen citizen = new Citizen(name);

                Console.WriteLine(person.GetName(name));
                Console.WriteLine(citizen.GetName(name));
            }
        }
    }
}
