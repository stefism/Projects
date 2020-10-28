using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public static Dictionary<string, int> Members { get; set; }
        public static Person currentPerson { get; set; }

        static  Family()
        {
            Members = new Dictionary<string, int>();
        }

        public static void AddMemberToDictionary(Person currentPerson)
        {
            Members[currentPerson.Name] = currentPerson.Age;
        }

        public static void PrintMembersThan30Age()
        {
            foreach (var member in Members.Where(x => x.Value > 30).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{member.Key} - {member.Value}");
            }
        }
    }
}
