using System;

namespace Graduation_RABOTI
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grades = 1;
            double sum = 0;

            while (grades <=12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade >= 4.00)
                {
                    sum += grade;
                    grades++;
                }
            }
            double average = sum / 12;
            Console.WriteLine($"{name} graduated. Average grade: {average:F2}");
        }
    }
}
