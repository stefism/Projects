using System;

namespace _04_CenturiesToMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());

            double daysInYear = 365.2422;
            double years = centuries * 100;
            double totalDays = Math.Floor(daysInYear * years);
            double hours = totalDays * 24;
            double minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {totalDays} days = " +
                $"{hours} hours = {minutes} minutes");
        }
    }
}
