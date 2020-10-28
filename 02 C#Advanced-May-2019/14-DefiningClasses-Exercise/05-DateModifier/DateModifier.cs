using System;

namespace _05_DateModifier
{
    public class DateModifier
    {
        public string DateOne { get; set; }
        public string DateTwo { get; set; }

        public DateModifier(string date1, string date2)
        {
            DateOne = date1;
            DateTwo = date2;
        }

        public int CalculateDays()
        {
            string[] date1 = DateOne.Split();
            string[] date2 = DateTwo.Split();

            int date1Year = int.Parse(date1[0]);
            int date1Month = int.Parse(date1[1]);
            int date1Day = int.Parse(date1[2]);

            DateTime date1date = new DateTime(date1Year, date1Month, date1Day);

            int date2Year = int.Parse(date2[0]);
            int date2Month = int.Parse(date2[1]);
            int date2Day = int.Parse(date2[2]);

            DateTime date2date = new DateTime(date2Year, date2Month, date2Day);

            var totalDays = (date2date.Date - date1date.Date).ToString();

            string[] date = totalDays.Split(".");
            int days = int.Parse(date[0]);

            return days;
        }
    }
}
