using System;

namespace _04_BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int minutesPlus30 = minutes + 30;

            if (minutesPlus30 > 59)
            {
                hour += 1;
                minutesPlus30 -= 60;

            }

            if (hour > 23)
            {
                hour = 0;
            }

            Console.WriteLine($"{hour}:{minutesPlus30:D2}");
        }
    }
}
