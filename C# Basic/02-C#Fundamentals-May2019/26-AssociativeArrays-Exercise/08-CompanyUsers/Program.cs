using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyAndUsers = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] currentInformation = Console.ReadLine().Split(" -> ");
                bool isIdExist = false;

                string companyName = currentInformation[0];

                if (companyName == "End")
                {
                    companyAndUsers = companyAndUsers.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                    foreach (var item in companyAndUsers)
                    {
                        Console.WriteLine($"{item.Key}");
                        Console.WriteLine($"-- {string.Join(Environment.NewLine + "-- ", item.Value)}");
                    }
                    break;
                }

                string companyId = currentInformation[1];

                if (!companyAndUsers.ContainsKey(companyName))
                {
                    companyAndUsers[companyName] = new List<string>();
                }

                foreach (var item in companyAndUsers)
                {
                    if (companyAndUsers[companyName].Contains(companyId)) // if (item.Value.Contains(companyId))
                    {
                        isIdExist = true;
                    }
                }

                if (!isIdExist)
                {
                    companyAndUsers[companyName].Add(companyId);
                }
            }

        }
    }
}
