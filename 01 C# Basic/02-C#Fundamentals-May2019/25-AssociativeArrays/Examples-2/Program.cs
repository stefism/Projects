using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var phones = new Dictionary<string, List<string>>();

            phones["Ivan"] = new List<string>
            {
                "25467859",
                "+3592 879 36 54",
                "Sofia, Mladost"
            };

            phones["Gosho"] = new List<string>
            {
                "Mobile: +359 879 546 589",
                "Home: +359 2 879 65 41",
                "Nadejda, Sofia, Bulgaria"
            };

            string key = "Stoyan";
            string value = "mail: stoyan@abv.bg";

            if (!phones.ContainsKey(key))
            {
                phones[key] = new List<string>();
            }

            phones[key].Add(value);

            foreach (var item in phones)
            {
                var currentValue = item.Value;
                Console.WriteLine($"{item.Key} -> {string.Join("; ", item.Value)}");
            }
        }
    }
}
