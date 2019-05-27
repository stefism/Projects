using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            //Technology Fundamentals Mid Exam - 10 March 2019 Group 2

            List<string> fireAndCell = Console.ReadLine().Split("#").ToList();
            int water = int.Parse(Console.ReadLine());

            List<int> cellValue = new List<int>();

            double effort = 0;
            double totalFire = 0;

            for (int cellInfo = 0; cellInfo < fireAndCell.Count; cellInfo++)
            {
                List<string> firePower = fireAndCell[cellInfo].Split("=").ToList();
                int firePowerValue = int.Parse(firePower[1]);
                string fireType = firePower[0].Trim();

                if (water <= 0)
                {
                    Console.WriteLine("Cells:");

                    foreach (var item in cellValue)
                    {
                        Console.WriteLine($"- {item}");
                    }

                    Console.WriteLine($"Effort: {effort:F2}");
                    Console.WriteLine($"Total Fire: {totalFire}");
                    return;
                }

                switch (fireType)
                {
                    case "High":
                        if (firePowerValue >= 81 && firePowerValue <= 125)
                        {
                            if (water < firePowerValue)
                            {
                                continue;
                            }
                            else
                            {
                                water -= firePowerValue;
                                cellValue.Add(firePowerValue);
                                effort += firePowerValue * 0.25;
                                totalFire += firePowerValue;
                                //fireAndCell.RemoveAt(cellInfo);
                            }
                        }
                        break;

                    case "Medium":
                        if (firePowerValue >= 51 && firePowerValue <= 80)
                        {
                            if (water < firePowerValue)
                            {
                                continue;
                            }
                            else
                            {
                                water -= firePowerValue;
                                cellValue.Add(firePowerValue);
                                effort += firePowerValue * 0.25;
                                totalFire += firePowerValue;
                                //fireAndCell.RemoveAt(cellInfo);
                            }
                        }
                        break;

                    case "Low":
                        if (firePowerValue >= 1 && firePowerValue <= 50)
                        {
                            if (water < firePowerValue)
                            {
                                continue;
                            }
                            else
                            {
                                water -= firePowerValue;
                                cellValue.Add(firePowerValue);
                                effort += firePowerValue * 0.25; 
                                totalFire += firePowerValue;
                                //fireAndCell.RemoveAt(cellInfo);
                            }
                        }
                        break;
                }
            }

            Console.WriteLine("Cells:");

            foreach (var item in cellValue)
            {
                Console.WriteLine($"- {item}");
            }

            Console.WriteLine($"Effort: {effort:F2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
