using System;

namespace TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int totalTime = hour * 60 + minutes + 15;

            int finalHour = totalTime / 60;
            int finalMinutes = totalTime % 60;

            if (finalHour == 24)
            {
                finalHour = 0;
            }

            if (finalMinutes <= 9)
            {
                Console.WriteLine(finalHour + ":0" + finalMinutes);
            }
            else
            {
                Console.WriteLine(finalHour + ":" + finalMinutes);
            }

            //int secondOfHour = hour * 60 * 60;
            //int secontOfMinutes = minutes * 60;

            //int totalSec = secondOfHour + secontOfMinutes + 900;
            //int hourOut = totalSec / 60 / 60;
            //int minuteOut = (totalSec / 60) % 60;

            //if (hourOut > 23)
            //{
            //    hourOut = 0;
            //}

            //if (minuteOut < 9)
            //{
            //    Console.WriteLine("{0}:0{1}", hourOut, minuteOut);
            //}
            //else
            //{
            //    Console.WriteLine("{0}:{1}", hourOut, minuteOut);
            //}
        }
    }
}
