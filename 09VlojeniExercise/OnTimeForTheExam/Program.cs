using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minOfExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minOfArrival = int.Parse(Console.ReadLine());

            int minutesOfExam = (hourOfExam * 60) + minOfExam;
            int minutesOfArrival = (hourOfArrival * 60) + minOfArrival;

            string inTime = "";

            if (minutesOfArrival > minutesOfExam)
            {
                inTime = "late";
            }
            else if (minutesOfArrival == minutesOfExam || minutesOfExam - minutesOfArrival <= 30)
            {
                inTime = "On Time";
            }
            else if (minutesOfExam - minutesOfArrival > 30)
            {
                inTime = "Early";
            }

            if (minutesOfExam - minutesOfArrival > 1 && minutesOfExam - minutesOfArrival < 60)
            {
                Console.WriteLine(inTime);
                Console.WriteLine($"{minutesOfExam - minutesOfArrival} minutes before the start");
            }
            else if (minutesOfExam - minutesOfArrival > 60)
            {
                int timeBefore = minutesOfExam - minutesOfArrival;
                int hourBefore = timeBefore / 60;
                int minuteBefore = timeBefore % 60;

                Console.WriteLine(inTime);
                if (minuteBefore <=9)
                {
                    Console.WriteLine($"{hourBefore}:0{minuteBefore} hours before the start");
                }
                else
                Console.WriteLine($"{hourBefore}:{minuteBefore} hours before the start");

            }


        }
    }
}
