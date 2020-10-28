using System;

namespace _02Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Grades();
        }

        static void Grades()
        {
            double grades = double.Parse(Console.ReadLine());
            string grade = "";

            if (grades >= 2.00 && grades <= 2.99)
            {
                grade = "Fail";
            }

            else if (grades >= 3.00 && grades <= 3.49)
            {
                grade = "Poor";
            }

            else if (grades >= 3.50 && grades <= 4.49)
            {
                grade = "Good";
            }

            else if (grades >= 4.50 && grades <= 5.49)
            {
                grade = "Very good";
            }

            else if (grades >= 5.50 && grades <= 6.00)
            {
                grade = "Excellent";
            }

            Console.WriteLine(grade);
        }
    }
}
