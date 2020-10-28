using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fires = Console.ReadLine().Split("#");
            int water = int.Parse(Console.ReadLine());

            List<int> fireCells = new List<int>();

            double efford = 0;

            for (int i = 0; i < fires.Length; i++)
            {
                string[] fireArgs = fires[i].Split(" = ");

                string type = fireArgs[0];
                int fireValue = int.Parse(fireArgs[1]);

                bool isCellValid = IsCellValid(type, fireValue);

                if (isCellValid && water - fireValue >= 0)
                {
                    efford += fireValue * 0.25;
                    water -= fireValue;
                    fireCells.Add(fireValue);
                }
            }

            int totalFire = fireCells.Sum();

            Console.WriteLine("Cells:");

            //Console.WriteLine(string.Join(Environment.NewLine, fireCells.Select(cell => $"- {cell}"))); // Прави същото като долното.

            foreach (var item in fireCells)
            {
                Console.WriteLine($"- {item}");
            }

            Console.WriteLine($"Effort: {efford:F2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
        static bool IsCellValid(string type, int fireValue)
        {
            if (type == "High")
            {
                return fireValue >= 81 && fireValue <= 125;
            }

            else if (type == "Medium")
            {
                return fireValue >= 51 && fireValue <= 80;
            }

            else if (type == "Low")
            {
                return fireValue >= 1 && fireValue <= 50;
            }

            return false;
        }
    }
}
