using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var mineralsValue = new Dictionary<string, int>();

            while (true)
            {
                string mineral = Console.ReadLine();

                if (mineral == "stop")
                {
                    foreach (var item in mineralsValue)
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value}");
                    }

                    break;
                }

                int mineralValue = int.Parse(Console.ReadLine());

                if (!mineralsValue.ContainsKey(mineral))
                {
                    mineralsValue[mineral] = mineralValue;
                }
                else
                {
                    mineralsValue[mineral] += mineralValue;
                }
            }
        }
    }
}
