using System;

namespace Scholarship_Stipendia_
{
    class Program
    {
        static void Main(string[] args)
        {
            double profitLeva = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarship =
                Math.Floor(minSalary * 0.35);

            double greatSuccessScholarship =
                averageSuccess * 25;

            //if (profitLeva > minSalary)
            //{
            //    Console.WriteLine("You cannot get a scholarship!");
            //}

            if (profitLeva < minSalary && averageSuccess > 4.5)
            {
                if (socialScholarship > greatSuccessScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Abs(Math.Floor(socialScholarship))} BGN");
                }
                else
                {
                    if (averageSuccess >= 5.50)
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {Math.Abs(Math.Floor(greatSuccessScholarship))} BGN");
                    }
                    else
                    {
                        Console.WriteLine($"You get a Social scholarship {Math.Abs(Math.Floor(socialScholarship))} BGN");
                    }
                }
            }
            //else
            //Console.WriteLine("You cannot get a scholarship!");

            else if (averageSuccess >= 5.5)
            {
                if (greatSuccessScholarship >=
                    socialScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Abs(Math.Floor(greatSuccessScholarship))} BGN");
                }
                else
                {
                    if (profitLeva < minSalary)
                    {
                        Console.WriteLine($"You get a Social scholarship {Math.Abs(Math.Floor(socialScholarship))} BGN");
                    }
                    else
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {Math.Abs(Math.Floor(greatSuccessScholarship))} BGN");
                    }
                }

            }
            else
                Console.WriteLine("You cannot get a scholarship!");

        }
    }
}