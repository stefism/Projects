using System;
using System.Linq;
using System.Collections.Generic;

namespace _01_CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var valuesHowTimesExist = new Dictionary<double, int>();

            foreach (var value in values)
            {
                if (!valuesHowTimesExist.ContainsKey(value))
                {
                    valuesHowTimesExist[value] = 0;
                }

                valuesHowTimesExist[value]++;
            }

            foreach (var item in valuesHowTimesExist)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
