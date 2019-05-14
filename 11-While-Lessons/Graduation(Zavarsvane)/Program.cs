using System;

namespace Graduation_Zavarsvane_
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameStudent = Console.ReadLine();
            int counter = 0;
            double averageSuccess = 0;
            double sumSuccess = 0;

            while (true)
            {
                if (counter < 12)
                {
                    averageSuccess = double.Parse(Console.ReadLine());
                    if (averageSuccess < 4) continue;
                    sumSuccess = averageSuccess + sumSuccess;
                    counter++;
                }
                else
                {
                    Console.WriteLine($"{nameStudent} graduated. Average grade: {(sumSuccess / 12):F2}");
                    break;
                }
                
                
            }

        }
    }
}
