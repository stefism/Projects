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

        public static string GetOldestMember()
        {
            int oldestYear = Members.Values.Max();
            string oldestName = Members.FirstOrDefault(x => x.Value == oldestYear).Key;

            return $"{oldestName} {oldestYear}";
        }
    }
}
