using System;
using System.Collections.Generic;
using System.Linq;

namespace _05m_DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double gabysMoney = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> initialQuality = new List<int>(drumSet);

            while (true)
            {
                string hit = Console.ReadLine();

                bool strike = int.TryParse(hit, out int power);

                if (!strike)
                {
                    Console.WriteLine(string.Join(" ", drumSet));
                    Console.WriteLine($"Gabsy has {gabysMoney:F2}lv.");
                    break;
                }

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= power;

                    if (drumSet[i] <= 0)
                    {
                        double drumPrice = initialQuality[i] * 3;

                        if (gabysMoney >= drumPrice)
                        {
                            gabysMoney -= drumPrice;
                            drumSet[i] = initialQuality[i];
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            initialQuality.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }
    }
}
