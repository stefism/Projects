using System;
using System.Linq;
using System.Collections.Generic;

namespace _07_SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            while (true)
            {
                string currentGuest = Console.ReadLine();

                if (currentGuest == "PARTY")
                {
                    break;
                }

                if (currentGuest.Length == 8)
                {
                    guests.Add(currentGuest);
                }
            }

            while (true)
            {
                string currentGuest = Console.ReadLine();

                if (currentGuest == "END")
                {
                    break;
                }

                guests.Remove(currentGuest);
            }

            Console.WriteLine(guests.Count);

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, guests));
            }
        }
    }
}
