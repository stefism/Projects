using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_RoliTheCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventsIdAndNames = new Dictionary<int, string>();
            var eventsAndMembers = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Time for Code")
            {
                int index = input.IndexOf("#");

                if (index == -1)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!char.IsLetterOrDigit(input[index+1]))
                {
                    input = Console.ReadLine();
                    continue;
                }

                string[] idAndEvent = input.Split(new string[] { " #" }, StringSplitOptions.RemoveEmptyEntries);

                if (idAndEvent.Length == 1)
                {
                    input = Console.ReadLine();
                    continue;
                }

                int eventId = int.Parse(idAndEvent[0]);

                List<string> eventNameAndMembers = idAndEvent[1]
                    .Split(new string[] { "@", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                string eventName = eventNameAndMembers[0];

                if (!eventsIdAndNames.ContainsKey(eventId))
                {
                    eventsIdAndNames[eventId] = eventName;
                    eventsAndMembers[eventName] = new List<string>();

                    if (eventNameAndMembers.Count > 1)
                    {
                        for (int i = 1; i < eventNameAndMembers.Count; i++)
                        {
                            eventsAndMembers[eventName].Add(eventNameAndMembers[i]);
                        }
                    }
                }
                else
                {
                    if (eventsIdAndNames[eventId] == eventName)
                    {
                        if (eventNameAndMembers.Count > 1)
                        {
                            eventNameAndMembers.RemoveAt(0);

                            foreach (var member in eventsAndMembers)
                            {
                                if (member.Key == eventName)
                                {
                                    foreach (var name in eventNameAndMembers)
                                    {
                                        if (!member.Value.Contains(name))
                                        {
                                            member.Value.Add(name);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var member in eventsAndMembers.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{member.Key} - {member.Value.Count}");

                if (member.Value.Count > 0)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, member.Value
                        .OrderBy(x => x).Select(x => $"@{x}")));
                }
            }
        }
    }
}
