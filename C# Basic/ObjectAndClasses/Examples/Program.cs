using System;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Date today = new Date();
            today.DayOfTheMonth = 25;
            today.Month = 2;
            today.Year = 2019;
            today.AddYear();

            Date yesterday = new Date();
            yesterday.Year = 2019;
            yesterday.Month = 2;
            yesterday.DayOfTheMonth = 24;
            yesterday.AddYear();
        }
    }

    class Date
    {
        public int Year;
        public int Month;
        public int DayOfTheMonth;

        public void AddYear()
        {
            Year++;
        }
    }
}
