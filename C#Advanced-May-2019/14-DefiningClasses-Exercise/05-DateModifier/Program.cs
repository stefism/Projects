using System;

namespace _05_DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier dateModifier = new DateModifier(date1, date2);

            int days = dateModifier.CalculateDays();

            Console.WriteLine(Math.Abs(days));
        }
    }
}
