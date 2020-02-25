using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int openTabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            int counterForOpenTabs = 0;
            // bool salaryDiferentFromZero = false;

            while (counterForOpenTabs < openTabs)
            {
                counterForOpenTabs ++;

                string webSite = Console.ReadLine();

                if (webSite == "Facebook")
                {
                    salary -= 150;
                }

                else if (webSite == "Instagram")
                {
                    salary -= 100;
                }

                else if (webSite == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
                //else
                //{
                //    salaryDiferentFromZero = false;
                //}

            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
            
        }
    }
}

